using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DigitalInventory
{
    public partial class MainForm
    {
        /// <summary>
        /// Called whenever the add button is clicked. Checks to see if there is
        /// a valid card name entered in the texbbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addCardButton_Click(object sender, EventArgs e)
        {
            if (this.cardNameToAdd.Text.Length == 0)
            {
                Console.WriteLine("No card selected.");
            }
            else
            {
                string name = this.cardNameToAdd.Text;
                name = name.Substring(0, name.LastIndexOf("-") < 0 ? 1 : name.LastIndexOf("-"));
                string set = name.Substring(name.LastIndexOf("-") + 1);
                if (SetDataHelper.CardExists(name)) //Add the card to inventory list
                {
                    Console.WriteLine("Found card.");
                    AddCardToListFromTextBox(this.cardNameToAdd.Text);
                }
            }
        }

        /// <summary>
        /// If the card name was validated as being a real card, interpret data
        /// about the card and then add it to the database.
        /// </summary>
        /// <param name="cardname">The name of the card being added</param>
        private void AddCardToListFromTextBox(string cardname)
        {
            string name = cardname.Substring(0, cardname.LastIndexOf("-"));
            string set = cardname.Substring(cardname.LastIndexOf("-") + 1);
            int quantity = Decimal.ToInt32(quantitySelection.Value);
            string condition = conditionSelection.SelectedItem.ToString();
            bool foil = FoilCheckBox.Checked;
            AddCardToDatabase(name, set, quantity, condition, foil);
            ResetCardParameters();
        }

        /// <summary>
        /// Adds a card to the database and prompts the user that a save is needed.
        /// Working on checking if the card is already in the database and if so
        /// updating the quantity rather than creating a new entry.
        /// </summary>
        /// <param name="cardname">Name of card being added</param>
        /// <param name="set">Set of card being added</param>
        /// <param name="quantity">Quantity of card being added</param>
        /// <param name="condition">Condition of card being added</param>
        private void AddCardToDatabase(string cardname, string set, int quantity, string condition, bool foil)
        {
            float price = SetDataHelper.GetPrice(cardname);
            //Check if database already contains a card, set, condition pair
            IEnumerable<InventoryDataSet.InventoryRow> rowsQuery =
                from row in inventoryDataSet.Inventory.AsEnumerable()
                where row.Name.Equals(cardname)
                where row.Set.Equals(set)
                where row.Condition.Equals(condition)
                where row.Foil.Equals(foil)
                select row;

            Console.WriteLine("Searched for card: {0}, set: {1}, cond: {2} and found {3} matches", cardname, set, condition, rowsQuery.Count());

            if (rowsQuery.Count() == 0)
            {
                string rarity = SetDataHelper.GetRarity(cardname, set);
                inventoryDataSet.Inventory.AddInventoryRow(cardname, set, quantity, condition, price, rarity, foil);
            }
            else
            {
                InventoryDataSet.InventoryRow row = rowsQuery.ElementAt(0);
                row.Quantity += quantity;
            }
            if (!saveNeeded)
            {
                NotifySaveNeeded();
            }
        }

        /// <summary>
        /// Called whenever the user clicks on the import from clipboard menu.
        /// item.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clipboardImportMenuItem_Click(object sender, EventArgs e)
        {
            ClipboardTextImport(sender);
        }

        /// <summary>
        /// Called when the user chooses import from text in the dropdown menu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textImportMenuItem_Click(object sender, EventArgs e)
        {
            ClipboardTextImport(sender);
        }

        /// <summary>
        /// Called by either the import from clipboard or text menu item. Creates
        /// a new ClipboardTextForm object and if the clipboard option was clicked
        /// sets the textbox contents equal to the text contents of the clipboard.
        /// </summary>
        /// <param name="sender">ToolStripMenuItem that was clicked to call this method</param>
        private void ClipboardTextImport(object sender)
        {
            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
            ClipboardTextForm clipboardImportForm = new ClipboardTextForm();
            clipboardImportForm.Size = new Size((int)(this.Size.Width * 0.5), (int)(this.Size.Height * 0.5));
            if (menuItem.Name.Equals("clipboardImportMenuItem"))
            {
                clipboardImportForm.clipboardTextbox.Text = Clipboard.GetText();
                clipboardImportForm.clipboardTextbox.TabIndex = 2;
                clipboardImportForm.clipboardTextbox.Select(0, 0);
            }
            //Sets the proper click handlers and shows the form
            clipboardImportForm.cancelCardsFromClip.Click += new System.EventHandler(this.cancelCards_Click);
            clipboardImportForm.addCardsFromClip.Click += new System.EventHandler(this.addCards_Click);
            clipboardImportForm.ShowDialog(this);
        }

        /// <summary>
        /// Called when the user chooses the cancel option on the ClipboardTextForm form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelCards_Click(object sender, EventArgs e)
        {
            ClipboardTextForm.ActiveForm.Close();
        }

        /// <summary>
        /// Called when the user chooses the add option on the ClipboardTextForm form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addCards_Click(object sender, EventArgs e)
        {
            ClipboardTextForm form = (ClipboardTextForm)ClipboardTextForm.ActiveForm;
            string rawCardsList = form.clipboardTextbox.Text;
            ParseCardData(rawCardsList);
            ClipboardTextForm.ActiveForm.Close();
        }

        /// <summary>
        /// Main load method that fills the DataGridView with the contents of
        /// the database and loads the set data via a SetDataHelper object.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            this.inventoryTableAdapter.Fill(this.inventoryDataSet.Inventory);
            SetDataHelper.Load();
            this.cardNameToAdd.AutoCompleteMode = AutoCompleteMode.Suggest;
            this.cardNameToAdd.AutoCompleteSource = AutoCompleteSource.CustomSource;
            this.cardNameToAdd.AutoCompleteCustomSource = SetDataHelper.AutoCompleteSource;
        }

        /// <summary>
        /// Called whenever the user clicks on a row/cell in the DataGridView and
        /// displays information about the card.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void inventoryDataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = e != null ? inventoryDataGridView.Rows[e.RowIndex] :
                inventoryDataGridView.Rows[inventoryDataGridView.Rows.GetFirstRow(DataGridViewElementStates.Selected)];
            if (row.Selected)
            {
                string cardName = (string)row.Cells[1].Value;
                string set = row.Cells[2].Value.ToString().Trim();
                int quantity = Convert.ToInt32(row.Cells[3].Value.ToString().Trim());
                string condition = row.Cells[4].Value.ToString().Trim();
                string price = row.Cells[5].Value.ToString().Trim();
                TcgPlayerHttpClient.RetrievePrice(cardName, set);
                string url = String.Format("http://gatherer.wizards.com/Handlers/Image.ashx?multiverseid={0}&type=card",
                    SetDataHelper.GathererIdForCard(cardName, set));
                //Load from wizards site and if the image isn't downloaded, download it
                try
                {
                    pictureBox1.Load(url);
                    if (Properties.Settings.Default.SaveLocalFiles && Properties.Settings.Default.LocalFilesDirectory != "")
                    {
                        string destPath = Path.Combine(Properties.Settings.Default.LocalFilesDirectory,
                            Convert.ToString(SetDataHelper.GathererIdForCard(cardName, set)) + ".png");
                        if (!File.Exists(destPath))
                        {
                            using (System.Net.WebClient client = new System.Net.WebClient())
                            {
                                try
                                {
                                    client.DownloadFile(url, destPath);
                                }
                                catch (System.Net.WebException ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                            }
                        }
                    }
                }
                catch (WebException) //If the image wasn't loaded, check for an offline copy and if one doesn't exist do nothing
                {
                    string destPath = Path.Combine(Properties.Settings.Default.LocalFilesDirectory,
                        Convert.ToString(SetDataHelper.GathererIdForCard(cardName, set)) + ".png");
                    if (File.Exists(destPath))
                    {
                        pictureBox1.Load(destPath);
                    }
                }
                nameLabel.Text = cardName;
                conditionLabel.Text = conditionLabel.Text.Split(':')[0] + ": " + condition;
                quantityLabel2.Text = quantityLabel2.Text.Split(':')[0] + ": " + quantity;
                priceLabel.Text = priceLabel.Text.Split(':')[0] + ": " + price;
            }
        }

        /// <summary>
        /// Called whenever the user chooses the save option. This will save any
        /// new changes to the database file since the last save.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NotifySaveDone();
        }

        /// <summary>
        /// Copies database to clipboard
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable table = inventoryDataSet.Inventory;
            StringBuilder stringb = new StringBuilder();
            foreach (DataRow row in table.Rows)
            {
                stringb.AppendFormat("{0} {1} {2} {3} {4}", row.ItemArray[1].ToString().Trim(' '),
                    "[" + row.ItemArray[2].ToString().Trim(' ') + "]", row.ItemArray[3].ToString().Trim(' '),
                    "[" + row.ItemArray[4].ToString().Trim(' ') + "]", "\n");
            }
            Clipboard.Clear();
            Clipboard.SetText(stringb.ToString());
        }

        /// <summary>
        /// Called when a user chooses the import from .txt file option. This
        /// method will display a file selector of .txt type in the user's documents
        /// folder and will then parse the text file as if the user had typed the text.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fromFiletxtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream fileStream = null;
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            openFile.Filter = "txt files (*.txt)|*.txt";
            openFile.FilterIndex = 1;
            openFile.RestoreDirectory = true;
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((fileStream = openFile.OpenFile()) != null)
                    {
                        using (fileStream)
                        {
                            using (var reader = new StreamReader(fileStream))
                            {
                                ParseCardData(reader.ReadToEnd());
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        /// <summary>
        /// This method is responsible for parsing card data when received from
        /// the textbox or a .txt file. It follows the following methodology.
        /// 1. Split the string into seperate lines by split via the \n and \r 
        /// literals.
        /// 2. For each string in the array, split via the space delimeter.
        /// 3. For each token, determine if it is a set, condition or name tag. 
        /// Name tags get added to the list of name pieces to be recombined at the end. 
        /// In order to determine if a tag is a condition or set tag, it has 
        /// its brackets removed and then if statements check whats what.
        /// 4. Once all the data has been parsed, it gets added to the database
        /// and tells the user they better save their shit otherwise the data
        /// isn't officially committed to the database.
        /// </summary>
        /// <param name="rawCardsList">
        /// The is the raw text data as a single string that will be parsed
        /// </param>
        private void ParseCardData(string rawCardsList)
        {
            string[] rawCardsArray = rawCardsList.Split(new Char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            bool importErrorFlag = false;
            foreach (string rawCardLine in rawCardsArray)
            {
                string[] cardTokens = rawCardLine.Trim().Split(' ');
                List<string> nameFrags = new List<string>();
                int quant = 1;
                string set = null;
                string condition = "NM";
                string name = "";
                bool foil = false;
                foreach (string s in cardTokens)
                {
                    //If the token is a number, it is the quantity or set code
                    //Try and parse as a tag first
                    if (Utils.IsInfoTag(s))
                    {
                        //Check if tag is a condition tag
                        string tag = Utils.ParseBracketTag(s).ToLower();
                        if (Utils.IsTagCondition(tag))
                        {
                            condition = tag.ToUpper();
                        }
                        else if (Utils.IsTagFoil(tag))
                        {
                            foil = true;
                        }
                        else
                        {
                            set = tag.ToUpper();
                        }
                    }
                    else if (Regex.IsMatch(s, @"\d")) //Check for quantity
                    {
                        string numVal = s;
                        try
                        {
                            quant = Convert.ToInt32(numVal.ToLower().Contains('x') ? numVal.ToLower().Replace("x", "") : numVal);
                        }
                        catch (ArgumentException)
                        {
                            quant = 1;
                        }
                    }
                    else //Token must be part of name
                    {
                        nameFrags.Add(s);
                    }
                }
                //At this point only tokens left should be card words
                StringBuilder nameBuild = new StringBuilder();
                foreach (string nameFrag in nameFrags)
                {
                    nameBuild.Append(Utils.FirstCharToUpper(nameFrag) + " ");
                }
                name = nameBuild.ToString().Trim(' ');
                //Check if card exists
                if (!SetDataHelper.CardExists(name))
                {
                    importErrorFlag = true;
                    Console.WriteLine("Card doesn't exist, tried looking for {0}", name);
                    continue;
                }
                //set = helper.getDefaultSet(name);
                if (set == null)
                {
                    set = SetDataHelper.DefaultSet(name);
                }
                else
                {
                    //Set doesn't even exist
                    if (SetDataHelper.SetForCode(set) == null)
                    {
                        importErrorFlag = true;
                        Console.WriteLine("Set code invalid, set {0}", set);
                        continue;
                    }
                    //Card was not in the set specified
                    if (!SetDataHelper.CardInSet(name, set))
                    {
                        importErrorFlag = true;
                        Console.WriteLine("Card was not in set");
                        continue;
                    }
                }
                AddCardToDatabase(name, set, quant, condition, foil);
            }
            if (importErrorFlag)
            {
                MessageBox.Show("Error importing one or more cards.");
            }
        }

        /// <summary>
        /// Prompts the user to select a .csv file to read and then parses the
        /// pertinent information.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fromFilecsvToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream fileStream = null;
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            openFile.Filter = "csv files (*.csv)|*.csv";
            openFile.FilterIndex = 1;
            openFile.RestoreDirectory = true;
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((fileStream = openFile.OpenFile()) != null)
                    {
                        using (fileStream)
                        {
                            using (TextFieldParser reader = new TextFieldParser(fileStream))
                            {
                                reader.CommentTokens = new string[] { "#" };
                                reader.SetDelimiters(new string[] { ",", ";" });
                                reader.HasFieldsEnclosedInQuotes = true;
                                string[] headers = reader.ReadFields();
                                if (headers.Length == 5)
                                {
                                    reader.SetDelimiters(new string[] { ";" });
                                }
                                while (!reader.EndOfData)
                                {
                                    string[] fields = reader.ReadFields();
                                    ParseCsvFields(fields);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        /// <summary>
        /// Parses a line from a deckbox.org csv file.
        /// </summary>
        /// <param name="fields">Array of values from the csv line</param>
        private void ParseCsvFields(string[] fields)
        {
            if (fields.Length == 5) //CSV file created by this program
            {
                string name = fields[0];
                string set = fields[1];
                int quantity = Convert.ToInt32(fields[2]);
                string condition = fields[3];
                string foil = fields[4];
                AddCardToDatabase(name, set, quantity, condition, foil.Equals("foil"));
            }
            else
            {
                int quantity = Convert.ToInt32(fields[0]);
                string name = fields[2];
                string condition = SetDataHelper.ShortenCondition(fields[5]);
                string set = SetDataHelper.DefaultSet(name);
                string foil = fields[7];
                AddCardToDatabase(name, set, quantity, condition, foil.Equals("foil"));
            }
        }

        /// <summary>
        /// Called when the user chooses to export the database to a .CSV file;
        /// prompts the person to select the destination and file name to save
        /// to and then saves it.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "CSV File|.csv";
            saveDialog.FilterIndex = 1;
            saveDialog.Title = "Save CSV File";
            saveDialog.RestoreDirectory = true;
            saveDialog.ShowDialog();

            if (saveDialog.FileName != "")
            {
                using (FileStream fs = (FileStream)saveDialog.OpenFile())
                {
                    StringBuilder sb = new StringBuilder();
                    IEnumerable<string> columnNames = from column in inventoryDataSet.Inventory.Columns.Cast<DataColumn>()
                                                      where column.ColumnName != "Id"
                                                      select column.ColumnName;
                    sb.AppendLine(string.Join(";", columnNames));
                    foreach (DataRow row in inventoryDataSet.Inventory.Rows)
                    {
                        IEnumerable<string> fields = from item in row.ItemArray
                                                     where item.ToString().IndexOf('-') != 0
                                                     select item.ToString().Trim();
                        sb.AppendLine(string.Join(";", fields));
                    }
                    fs.Close();
                    File.WriteAllText(saveDialog.FileName, sb.ToString().Trim());
                }
            }
        }


        /// <summary>
        /// Shows the pricing settings menu form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pricingRulesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //PricingRulesForm form = new PricingRulesForm();
            //form.ShowDialog(this);
        }

        /// <summary>
        /// Removes the right clicked row from the database afte prompting the
        /// user if they are sure about removing it.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedDataRow = inventoryDataGridView.SelectedRows[0];
            //InventoryDataSet.InventoryRow selectedInventoryRow = (InventoryDataSet.InventoryRow)((DataRowView)selectedDataRow.DataBoundItem).Row;
            if (selectedDataRow != null)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to remove this row?", "Warning", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    inventoryDataGridView.Rows.Remove(selectedDataRow);
                    inventoryDataGridView.ClearSelection();
                    NotifySaveNeeded();
                }
            }
        }

        private void showOnTCGPlayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InventoryDataSet.InventoryRow selectedInventoryRow = RightClickedInventoryRow();
            if (selectedInventoryRow != null)
            {
                string cardName = selectedInventoryRow.Name;
                string set = selectedInventoryRow.Set;
                System.Diagnostics.Process.Start(SetDataHelper.CreateTCGPlayerURL(cardName, set));
            }
        }

        private void inventoryDataGridView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hti = inventoryDataGridView.HitTest(e.X, e.Y);
                inventoryDataGridView.ClearSelection();
                inventoryDataGridView.Rows[hti.RowIndex].Selected = true;
                inventoryDataGridView_RowEnter(null, null);
            }
        }

        private void settingsMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm form = new SettingsForm();
            form.ShowDialog(this);
        }

        /// <summary>
        /// Creates a new trade form via the TradeManager.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newTradeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TradeForm tradeForm = new TradeForm();
            tradeForm.ShowDialog(this);
        }

        /// <summary>
        /// Creates a trade with the selected card added to the user's side.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addToTradeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TradeForm tradeForm = new TradeForm();
            InventoryDataSet.InventoryRow selectedInventoryRow = RightClickedInventoryRow();
            if (selectedInventoryRow != null)
            {
                string cardName = selectedInventoryRow.Name;
                string set = selectedInventoryRow.Set;
                int quantity = selectedInventoryRow.Quantity;
                CardListItem item = new CardListItem(cardName, set, quantity);
                tradeForm.AddCard(item);
                tradeForm.ShowDialog(this);
            }
        }

        private InventoryDataSet.InventoryRow RightClickedInventoryRow()
        {
            DataGridViewRow selectedDataRow = inventoryDataGridView.SelectedRows[0];
            InventoryDataSet.InventoryRow selectedInventoryRow = (InventoryDataSet.InventoryRow)((DataRowView)selectedDataRow.DataBoundItem).Row;
            if (selectedDataRow != null)
            {
                return selectedInventoryRow;
            }
            return null;
        }

        /// <summary>
        /// Shows the general settings menu form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void shopInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm form = new SettingsForm();
            form.ShowDialog(this);
        }

    }
}

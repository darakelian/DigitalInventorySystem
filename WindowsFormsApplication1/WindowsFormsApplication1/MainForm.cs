using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DigitalInventory
{
    public partial class MainForm : Form
    {
        
        private SetDataHelper helper;
        //private DataTable table;

        public MainForm()
        {
            InitializeComponent();
        }

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
                if (helper.CardExists(name)) //Add the card to inventory list
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
        /// <param name="cardname">The name of the card being added.</param>
        private void AddCardToListFromTextBox(string cardname)
        {
            string name = cardname.Substring(0, cardname.LastIndexOf("-"));
            string set = cardname.Substring(cardname.LastIndexOf("-") + 1);
            int quantity = Decimal.ToInt32(quantitySelection.Value);
            string condition = conditionSelection.SelectedItem.ToString();
            AddCardToDatabase(name, set, quantity, condition);
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
        private void AddCardToDatabase(string cardname, string set, int quantity, string condition)
        {
            float price = helper.GetPrice(cardname);
            //Check if database already contains a card, set, condition pair
            IEnumerable<InventoryDataSet.InventoryRow> rowsQuery = 
                from row in inventoryDataSet.Inventory.AsEnumerable()
                    where row.Name.Equals(cardname)
                    where row.Set.Trim().Equals(set)
                    where row.Condition.Trim().Equals(condition)
                select row;

            Console.WriteLine("Searched for card: {0}, set: {1}, cond: {2} and found {3} matches", cardname, set, condition, rowsQuery.Count());

            if (rowsQuery.Count() == 0)
            {
                inventoryDataSet.Inventory.AddInventoryRow(cardname, set, quantity, condition, price);
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
            helper = new SetDataHelper();
            this.cardNameToAdd.AutoCompleteMode = AutoCompleteMode.Suggest;
            this.cardNameToAdd.AutoCompleteSource = AutoCompleteSource.CustomSource;
            this.cardNameToAdd.AutoCompleteCustomSource = helper.AutoCompleteSource;
        }

        /// <summary>
        /// Called whenever the user clicks on a cell in the DataGridView and
        /// displays information about the card.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void inventoryDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (dgv == null)
                return;
            if (dgv.CurrentRow.Selected)
            {
                DataGridViewCell cell = dgv.CurrentRow.Cells[1];
                cardNameLabel1.Text = (string)cell.Value;
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
        /// Value storing if a save is needed (aka if new data was put into the
        /// database).
        /// </summary>
        private bool saveNeeded = false;

        /// <summary>
        /// Called whenever a card is added. This indicates that the user should
        /// save the database.
        /// </summary>
        private void NotifySaveNeeded()
        {
            this.Text = this.Text + "*";
            saveNeeded = true;
        }

        /// <summary>
        /// Called whenever the user indicates to save the database. This removes the
        /// asterisk from the title and saves the database.
        /// </summary>
        private void NotifySaveDone()
        {
            this.Text = this.Text.TrimEnd('*');
            saveNeeded = false;
            
            inventoryBindingSource.EndEdit();
            inventoryTableAdapter.Update(inventoryDataSet.Inventory);
        }

        /// <summary>
        /// Called as the form is closing. If there changes to the databse that
        /// weren't saved, prompts the user to double check if they want to exit
        /// via a DialogResult box. If yes, exits without saving, if no, stops
        /// the form from closing.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (saveNeeded)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to close without saving? " +
                    "Your cards will not be saved", "Warning", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        /// <summary>
        /// Clears the textbox, sets condition selection to NM and quantity to 1.
        /// </summary>
        private void ResetCardParameters()
        {
            cardNameToAdd.Text = "";
            conditionSelection.SelectedIndex = 0;
            quantitySelection.Value = 1;
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
                stringb.AppendFormat("{0} {1} {2} {3}", row.ItemArray[1].ToString().Trim(' '),
                    "[" + row.ItemArray[2].ToString().Trim(' ') + "]", row.ItemArray[3].ToString().Trim(' '), 
                    "[" + row.ItemArray[4].ToString().Trim(' ') + "]");
                stringb.AppendLine();
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
                foreach (string s in cardTokens)
                {
                    //If the token is a number, it is the quantity or set code
                    //Try and parse as a tag first
                    if (Utils.IsSetOrCondition(s))
                    {
                        //Check if tag is a condition tag
                        string tag = Utils.ParseBracketTag(s).ToLower();
                        if (Utils.IsTagCondition(tag))
                        {
                            condition = tag.ToUpper();
                        }
                        else
                        {
                            set = tag.ToUpper();
                        }
                    }
                    else if (Regex.IsMatch(s, @"\d")) //Check for quantity
                    {
                        string numVal = s;
                        if (numVal.ToLower().Contains('x'))
                        {
                            numVal = numVal.Replace("x", "");
                        }
                        try
                        {
                            quant = Convert.ToInt32(numVal);
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
                if (!helper.CardExists(name))
                {
                    importErrorFlag = true;
                    Console.WriteLine("Card doesn't exist, tried looking for {0}", name);
                    continue;
                }
                //set = helper.getDefaultSet(name);
                if (set == null)
                {
                    set = helper.DefaultSet(name);
                }
                else
                {
                    //Set doesn't even exist
                    if (helper.SetForCode(set) == null)
                    {
                        importErrorFlag = true;
                        Console.WriteLine("Set code invalid, set {0}", set);
                        continue;
                    }
                    //Card was not in the set specified
                    if (!helper.CardInSet(name, set))
                    {
                        importErrorFlag = true;
                        Console.WriteLine("Card was not in set");
                        continue;
                    }
                }
                AddCardToDatabase(name, set, quant, condition);
            }
            if (importErrorFlag)
            {
                MessageBox.Show("Error importing one or more cards.");
            }
        }
    }
}

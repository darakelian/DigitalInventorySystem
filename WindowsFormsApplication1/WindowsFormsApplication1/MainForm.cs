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
        /// about the card and then add it to the data base.
        /// </summary>
        /// <param name="cardname">The name of the card being added.</param>
        private void AddCardToListFromTextBox(string cardname)
        {
            string name = cardname.Substring(0, cardname.LastIndexOf("-"));
            string set = cardname.Substring(cardname.LastIndexOf("-") + 1);
            int quantity = Decimal.ToInt32(quantitySelection.Value);
            string condition = conditionSelection.SelectedItem.ToString();
            float price = helper.getPrice(name);
            inventoryDataSet.Inventory.AddInventoryRow(name, set, quantity, condition, price);
            if (!saveNeeded)
            {
                NotifySaveNeeded();
            }
            ResetCardParameters();
        }

        private void AddCardToListFromClipboard(string cardname, string set, int quantity, string condition)
        {
            float price = helper.getPrice(cardname);
            //Check if database already contains a card, set, condition pair
            IEnumerable<DataRow> rowsQuery =
                from row in inventoryDataSet.Inventory.AsEnumerable()
                where row.Name.Equals(cardname)
                where row.Condition.Equals(condition)
                where row.Set.Equals(set)
                select row;
            Console.WriteLine("There were {0} rows with the criteria matched.", rowsQuery.Count());

            inventoryDataSet.Inventory.AddInventoryRow(cardname, set, quantity, condition, price);
            if (!saveNeeded)
            {
                NotifySaveNeeded();
            }
        }

        private void clipboardImportMenuItem_Click(object sender, EventArgs e)
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
            clipboardImportForm.cancelCardsFromClip.Click += new System.EventHandler(this.cancelCards_Click);
            clipboardImportForm.addCardsFromClip.Click += new System.EventHandler(this.addCards_Click);
            clipboardImportForm.ShowDialog(this);
        }

        private void cancelCards_Click(object sender, EventArgs e)
        {
            ClipboardTextForm.ActiveForm.Close();
        }

        private void addCards_Click(object sender, EventArgs e)
        {
            ClipboardTextForm form = (ClipboardTextForm)ClipboardTextForm.ActiveForm;
            string rawCardsList = form.clipboardTextbox.Text;
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
                    if (helper.SetForCode(set) == null) {
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
                AddCardToListFromClipboard(name, set, quant, condition);
            }
            if (importErrorFlag)
            {
                MessageBox.Show("Error importing one or more cards.");
            }
            ClipboardTextForm.ActiveForm.Close();
        }

        private void textImportMenuItem_Click(object sender, EventArgs e)
        {
            clipboardImportMenuItem_Click(sender, e);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.inventoryTableAdapter.Fill(this.inventoryDataSet.Inventory);

            //Load set data
            using (var stream = new MemoryStream(Properties.Resources.AllSetsArray))
            {
                using (var reader = new StreamReader(stream))
                {
                    HashSet<string> cardHash = new HashSet<string>(); //Hash of each unique card name
                    Dictionary<string, string[]> setDictionary = new Dictionary<string, string[]>(); //Dictionary of set code and the card names in each set
                    Dictionary<string, int> multiverseDictionary = new Dictionary<string, int>();
                    Dictionary<string, string[]> mciDictionary = new Dictionary<string, string[]>();
                    List<string> cards = new List<string>();

                    string json = reader.ReadToEnd();
                    List<SetInfo> sets = JsonConvert.DeserializeObject<List<SetInfo>>(json);

                    if (sets != null)
                    {
                        foreach (SetInfo set in sets)
                        {
                            string setCode = set.code.ToUpper(); //Uppercase 3-4 character code of set
                            string[] _cards = new string[set.cards.Length]; //Array of card names in set
                            for (int i = 0; i < set.cards.Length; i++)
                            {
                                Card card = set.cards[i];
                                cards.Add(card.name + "-" + setCode);
                                cardHash.Add(card.name);
                                _cards[i] = card.name;
                            }
                            setDictionary.Add(setCode, _cards);
                        }
                        this.cardNameToAdd.AutoCompleteMode = AutoCompleteMode.Suggest;
                        this.cardNameToAdd.AutoCompleteSource = AutoCompleteSource.CustomSource;
                        AutoCompleteStringCollection acsc = new AutoCompleteStringCollection();
                        acsc.AddRange(cards.ToArray());
                        this.cardNameToAdd.AutoCompleteCustomSource = acsc;
                        helper = new SetDataHelper(cardHash, setDictionary, multiverseDictionary);
                    }
                }
            }
        }

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
            inventoryDataSetBindingSource.EndEdit();
            inventoryTableAdapter.Update(inventoryDataSet.Inventory);
        }

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
                //for (int i = 1; i < row.ItemArray.Length; i++)
                //{
                //  object item = row.ItemArray[i];
                //  stringb.Append(item.ToString() + " ");
                //}
                stringb.AppendFormat("{0} {1} {2} {3}", row.ItemArray[1].ToString().Trim(' '),
                    "[" + row.ItemArray[2].ToString().Trim(' ') + "]", row.ItemArray[3].ToString().Trim(' '), 
                    "[" + row.ItemArray[4].ToString().Trim(' ') + "]");
                stringb.AppendLine();
            }
            Clipboard.Clear();
            Clipboard.SetText(stringb.ToString());
        }
    }
}

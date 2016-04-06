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
                            string setCode = set.code; //Uppercase 3-4 character code of set
                            string[] _cards = new string[set.cards.Length]; //Array of card names in set
                            for(int i = 0; i < set.cards.Length; i++)
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
                if (helper.cardExists(name)) //Add the card to inventory list
                {
                    Console.WriteLine("Found card.");
                    addCardToListFromTextBox(this.cardNameToAdd.Text);
                }
            }
        }

        private void addCardToListFromTextBox(string cardname)
        {
            string name = cardname.Substring(0, cardname.LastIndexOf("-"));
            string set = cardname.Substring(cardname.LastIndexOf("-") + 1);
            int quantity = Decimal.ToInt32(quantitySelection.Value);
            string condition = conditionSelection.SelectedItem.ToString();
            float price = getPrice(name);
            inventoryDataSetBindingSource.EndEdit();
            inventoryDataSet.Inventory.AddInventoryRow(name, set, quantity, condition, price);
            inventoryTableAdapter.Update(inventoryDataSet.Inventory);
        }

        private void addCardToListFromClipboard(string cardname, string set, int quantity, string condition)
        {
            float price = getPrice(cardname);
            inventoryDataSetBindingSource.EndEdit();
            inventoryDataSet.Inventory.AddInventoryRow(cardname, set, quantity, condition, price);
            inventoryTableAdapter.Update(inventoryDataSet.Inventory);
        }

        private float getPrice(string card)
        {
            return 2.00F;
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
                //List<string> cardTokens = new List<string>();
                //cardTokens.AddRange(rawCardLine.Trim().Split(' '));
                List<string> nameFrags = new List<string>();
                int quant = 1;
                string set = null;
                string condition = "NM";
                string name = "";
                foreach (string s in cardTokens)
                {
                    //If the token is a number, it is the quantity or set code
                    if (Regex.IsMatch(s, @"\d"))
                    {
                        string numVal = s;
                        if (numVal.ToLower().IndexOfAny(new char[] { '(', ')', '[', ']'}) != -1) //Set code with number
                        {
                            set = helper.parseBracketTagAsSet(s);
                            continue;
                        }
                        if (numVal.ToLower().Contains("x"))
                        {
                            numVal = numVal.Replace("x", "");
                        }
                        quant = Convert.ToInt32(numVal);
                    }
                    else if (s.Contains("[") || s.Contains("(")) //Either set or condition
                    {
                        string tag = helper.parseBracketTag(s);
                        if (tag.Equals("nm") || tag.Equals("lp") || tag.Equals("mp") || tag.Equals("hp"))
                        {
                            condition = tag.ToUpper();
                        }
                        else
                        {
                            set = tag.ToUpper();
                        }
                    }
                    else
                    {
                        nameFrags.Add(s);
                    }
                }
                //At this point only tokens left should be card words
                StringBuilder nameBuild = new StringBuilder();
                foreach (string nameFrag in nameFrags)
                {
                    nameBuild.Append(firstCharToUpper(nameFrag) + " ");
                }
                name = nameBuild.ToString().Trim(' ');
                //Check if card exists
                if (!helper.cardExists(name))
                {
                    importErrorFlag = true;
                    Console.WriteLine("Card doesn't exist, tried looking for {0}", name);
                    continue;
                }
                //set = helper.getDefaultSet(name);
                if (set == null)
                {
                    set = helper.getDefaultSet(name);
                }
                if (set != null)
                {
                    //Set doesn't even exist
                    if (helper.getSetForCode(set) == null) {
                        importErrorFlag = true;
                        Console.WriteLine("Set code invalid, set {0}", set);
                        continue;
                    }
                    //Card was not in the set specified
                    if (!helper.cardInSet(name, set))
                    {
                        importErrorFlag = true;
                        Console.WriteLine("Card was not in set");
                        continue;
                    }
                }
                addCardToListFromClipboard(name, set, quant, condition);
            }
            if (importErrorFlag)
            {
                MessageBox.Show("Error importing one or more cards.");
            }
            ClipboardTextForm.ActiveForm.Close();
        }

        private string firstCharToUpper(string input)
        {
            if (String.IsNullOrEmpty(input))
                throw new ArgumentException("ARGH!");
            return input.First().ToString().ToUpper() + input.Substring(1);
        }

        private void textImportMenuItem_Click(object sender, EventArgs e)
        {
            clipboardImportMenuItem_Click(sender, e);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'inventoryDataSet.Inventory' table. You can move, or remove it, as needed.
            this.inventoryTableAdapter.Fill(this.inventoryDataSet.Inventory);
        }

        private void inventoryDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (dgv == null)
                return;
            if (dgv.CurrentRow.Selected)
            {
                Console.WriteLine("Clicked a selected row");
                Console.WriteLine(dgv.CurrentRow.Cells[0]);
            }
        }
    }
}

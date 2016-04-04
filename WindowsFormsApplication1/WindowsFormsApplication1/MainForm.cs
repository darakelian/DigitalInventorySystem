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

namespace WindowsFormsApplication1
{
    public partial class MainForm : Form
    {
        public HashSet<string> cardHash = new HashSet<string>();
        public List<string> cards;
        //public HashSet<string> setListHash = new HashSet<string>();
        public List<SetInfo> sets = new List<SetInfo>();

        public MainForm()
        {
            InitializeComponent();
            //Load set data
            using (var stream = new MemoryStream(Properties.Resources.AllSetsArray))
            {
                using (var reader = new StreamReader(stream))
                {
                    string json = reader.ReadToEnd();
                    sets = JsonConvert.DeserializeObject<List<SetInfo>>(json);
                    cards = new List<string>();
                    if (sets != null)
                    {
                        foreach (SetInfo set in sets)
                        {
                            string setCode = set.code;
                            //setListHash.Add(setCode);
                            foreach (Card card in set.cards)
                            {
                                cards.Add(card.name + "-" + setCode);
                                cardHash.Add(card.name);
                            }
                        }
                        this.cardNameToAdd.AutoCompleteMode = AutoCompleteMode.Suggest;
                        this.cardNameToAdd.AutoCompleteSource = AutoCompleteSource.CustomSource;
                        AutoCompleteStringCollection acsc = new AutoCompleteStringCollection();
                        acsc.AddRange(cards.ToArray());
                        this.cardNameToAdd.AutoCompleteCustomSource = acsc;
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
                if (cardHash.Contains(name)) //Add the card to inventory list
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
            string price = getPrice(name);
            inventoryGridView.Rows.Add(name, set, quantity, condition, price);
        }

        private void addCardToListFromClipboard(string cardname, string set, int quantity, string condition)
        {
            string price = getPrice(cardname);
            inventoryGridView.Rows.Add(cardname, set, quantity, condition, price);
        }

        private string getPrice(string card)
        {
            return "$0.00";
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
                    //If the token is a number, it is the quantity
                    if (Regex.IsMatch(s, @"\d"))
                    {
                        string numVal = s;
                        if (numVal.ToLower().Contains("x"))
                        {
                            numVal = numVal.Replace("x", "");
                        }
                        quant = Convert.ToInt32(numVal);
                    }
                    else if (s.Contains("[") || s.Contains("("))
                    {
                        string conditionOrSet = s.Contains("[") ? s.Trim(new char[] {'[', ']'}) : s.Trim(new char[] { '(', ')' });
                        conditionOrSet = conditionOrSet.ToLower();
                        if (conditionOrSet.Equals("nm") || conditionOrSet.Equals("lp") || conditionOrSet.Equals("mp") || conditionOrSet.Equals("hp"))
                        {
                            condition = conditionOrSet.ToUpper();
                        }
                        else
                        {
                            set = conditionOrSet.ToUpper();
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
                if (!cardHash.Contains(name))
                {
                    importErrorFlag = true;
                    continue;
                }
                if (set != null)
                {
                    //Set doesn't even exist
                    if (getSetForCode(set) == null) {
                        importErrorFlag = true;
                        continue;
                    }
                    //Card was not in the set specified
                    if (!cardInSet(name, set))
                    {
                        importErrorFlag = true;
                        continue;
                    }
                }
                if (set == null)
                {
                    set = getDefaultSet(name);
                }
                addCardToListFromClipboard(name, set, quant, condition);
            }
            if (importErrorFlag)
            {
                MessageBox.Show("Error importing one or more cards.");
            }
            ClipboardTextForm.ActiveForm.Close();
        }

        private bool cardInSet(string name, string code)
        {
            SetInfo set = getSetForCode(code);
            if (set == null)
            {
                return false;
            }
            foreach (Card card in set.cards)
            {
                if (card.name.ToLower().Equals(name.ToLower()))
                {
                    return true;
                }
            }
            return false;
        }
        private SetInfo getSetForCode(string code)
        {
            foreach (SetInfo set in sets)
            {
                if (set.code.ToLower().Equals(code.ToLower()))
                {
                    return set;
                }
            }
            return null;
        }

        private string getDefaultSet(string name)
        {
            foreach (SetInfo set in sets)
            {
                if (cardInSet(name, set.code))
                {
                    return set.code;
                }
            }
            return "TST";
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

        private void inventoryGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (dgv == null)
                return;
            if (dgv.CurrentRow.Selected)
            {
                Console.WriteLine("Clicked a selected row");
                //If we clicked on the condition cell
                string cardName = (string)dgv.CurrentRow.Cells[0].Value;
                this.cardNameLabel1.Text = cardName;
            }
        }
    }
}

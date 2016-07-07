using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace moneyform
{
    // made some pretty big changes
    // used NumericUpDown components instead of textboxes for numeric filtering)
    // I separated the direct references to Money attributes to only get values.
    // in general you always want to separate the underlying code (Money.cs) from your forms.
    // underlying code is for storing and processing data. the form is for displaying it.
    // the form should only alter it's interpretation of the data presented by the underlying code, it should never directly alter it.
    // user input should be passed back to the underlying code, translated by the form.
    public partial class Form1 : Form
    {
        // initialize _money so that we can work with it.
        // naming wise, "_" notes that this is private and readonly, meaning that once it's initialized, you cannot change it's reference.
        // you can however change it's non-readonly attributes (such as IncomeList).
        private readonly Money _money = new Money();


        public Form1()
        {
            InitializeComponent();

            // populate the combo box with a new item for every type of expense
            foreach (var name in Enum.GetNames(typeof (ExpenseType)))
            {
                ExpenseCB.Items.Add(name);
            }
            // set the current combo box item to 0 so that it's not blank
            ExpenseCB.SelectedIndex = 0;
        }

        private void AddExpenseBtn_Click(object sender, EventArgs e)
        {
            if (ExpenseCB.SelectedItem != null)
            {
                // parse the Expense type we have from the combobox, and convert the value of the expenseNUD, pass values back to Money
                _money.AddExpense((ExpenseType) Enum.Parse(typeof (ExpenseType), ExpenseCB.Text),
                    Convert.ToDouble(ExpenseNUD.Value));
                // update balance, Total income, and Breakdown components
                RecalculateTotals();
            }
        }

        private void AddIncomeBtn_Click(object sender, EventArgs e)
        {
            // get income value and pass it to Money
            _money.AddIncome(Convert.ToDouble(IncomeNUD.Value));
            // update balance, Total income, and Breakdown components
            RecalculateTotals();
        }

        // used to update the new values of balance, total income, and the breakdown chart.
        private void RecalculateTotals()
        {
            // setting the CultureInfo is largely unneccessary, but my style definitions from work were complaining about them.
            BalanceTB.Text = _money.Balance().ToString(CultureInfo.CurrentCulture);
            TotalIncomeTB.Text = _money.IncomeList.Sum().ToString(CultureInfo.CurrentCulture);
            GenerateBreakDown();
        }

        //  we need to update the model of the DataGridView to match changes to our expenses.
        // because we want the to show a text value for the expense types, we need to do some ugly collection work.
        // really not happy with this, might revisit.
        private void GenerateBreakDown()
        {
            // Alternative 1
            // use a dictionary instead, had to figure out another way to do the data source binding as doing it normally doesnt work.
            /*
            Dictionary<string, double> newExpensesModel = Enum.GetNames(typeof (ExpenseType)).ToDictionary<string, string, double>(name => name, name => 0);
            foreach (var expense in _money.ExpenseList)
            {
                newExpensesModel[Enum.GetName(typeof (ExpenseType), expense.Type)] += expense.Amount;
            }
            BreakDownDGV.DataSource = new BindingSource(newExpensesModel, null);
            */

            // Alternative 2
            // use LINQ to build the array
            // efficient, but not as verbose on exactly what is happening here. LINQ is amazing, but hard to understand compared to the standard methods.
            // this method will only add datapoints that exist in the expenses array, which may be better in the end *shrug*.
            BreakDownDGV.DataSource =
                new BindingSource(
                    _money.ExpenseList.GroupBy(x => x.Type)
                        .Select(y => new {Type = y.Key, value = y.Sum(z => z.Amount)}), null);

            //Original method. I dislike it greatly, but will leave as an example of another way to solve this
            // create a new model.
            /* 
            var newExpenses = new BindingList<KeyValuePair<string, double>>();
            foreach (var name in Enum.GetNames(typeof(ExpenseType)))
            {
                newExpenses.Add(new KeyValuePair<string, double>(name, 0));
            }
            // for every expense
            foreach (var expense in _money.ExpenseList)
            {
                // find the appropriate keypair
                for (var i = 0; i < Enum.GetNames(typeof(ExpenseType)).Length; i++)
                {
                    // if it's the right keypair, take the current value, add the expense amount, and alter the KeyValuePair to reflect the new expense.
                    if (newExpenses[i].Key == Enum.GetName(typeof(ExpenseType), expense.Type))
                    {
                        // keyvaluepairs are immutable, so you need to make a new one every time you change the value
                        newExpenses[i] =
                            new KeyValuePair<string, double>(Enum.GetName(typeof(ExpenseType), expense.Type),
                                newExpenses[i].Value + expense.Amount);
                    }
                }
            }
            // we are done, so overwrite the old model with the new one
            BreakDownDGV.DataSource = newExpenses;
            */
        }
    }
}
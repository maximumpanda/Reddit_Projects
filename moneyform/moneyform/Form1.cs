using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        private readonly Money _money = new Money();


        public Form1()
        {
            InitializeComponent();

            // use a bindinglist for our DataGridView as it has some additional events that fire when values change.
            var expenses = new BindingList<KeyValuePair<string, double>>();
            //bind _expenses to the DataGridView
            BreakDownDGV.DataSource = expenses;

            // populate the combo box with a new item for every type of expense
            foreach (var name in Enum.GetNames(typeof(ExpenseType)))
            {
                ExpenseCB.Items.Add(name);
                expenses.Add(new KeyValuePair<string, double>(name, 0));
            }
            // set the current combo box item to 0 so that it's not blank
            ExpenseCB.SelectedIndex = 0;
        }

        private void AddExpenseBtn_Click(object sender, EventArgs e)
        {
            if (ExpenseCB.SelectedItem != null)
            {
                // parse the Expense type we have from the combobox, and convert the value of the expenseNUD, pass values back to Money
                _money.AddExpense((ExpenseType) Enum.Parse(typeof(ExpenseType), ExpenseCB.Text),
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

        private void RecalculateTotals()
        {
            BalanceTB.Text = _money.Balance().ToString(CultureInfo.CurrentCulture);
            TotalIncomeTB.Text = _money.IncomeList.Sum().ToString(CultureInfo.CurrentCulture);
            GenerateBreakDown();
        }

        //  we need to update the model of the DataGridView to match our expenses.
        private void GenerateBreakDown()
        {
            // create a new model.
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
        }
    }
}
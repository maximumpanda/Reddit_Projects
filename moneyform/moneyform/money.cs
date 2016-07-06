using System.Collections.Generic;
using System.Linq;

namespace moneyform
{
    public class Money
    {
        public readonly List<ExpenseRecord> ExpenseList = new List<ExpenseRecord>();
        // I cut down to 2 lists to store all the data.
        public readonly List<double> IncomeList = new List<double>();

        //unique method for income
        public void AddIncome(double income)
        {
            IncomeList.Add(income);
        }

        //generalized recording expenses
        public void AddExpense(ExpenseType type, double expense)
        {
            ExpenseList.Add(new ExpenseRecord(type, expense));
        }

        //calculates the current balance.
        public double Balance()
        {
            return IncomeList.Sum() - ExpenseList.Sum(x => x.Amount);
        }
    }
}
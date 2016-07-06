namespace moneyform
{
    // custom class to hold records of expenses so that we can use them in a list easily.
    public class ExpenseRecord
    {
        public ExpenseRecord(ExpenseType type, double amount)
        {
            Type = type;
            Amount = amount;
        }

        public ExpenseType Type { get; }
        public double Amount { get; }
    }
}
namespace moneyform
{
    // enum that describes the possible expense types.
    // using an enum instead of text gives you an intellisense backed way to reference these types.
    // strings are risky because you can mistype them and cause mayhem, you cannot mistype these.
    // additionally an enum is far more efficient than a string. each value is represented by an int, so it takes 4 bytes rather than 100's
    // this matters when you have potentially 10,000's of records if you use this for a longtime.
    public enum ExpenseType
    {
        CarPayments,
        Insurance,
        Misc,
        Rent,
        Utilities
    }
}
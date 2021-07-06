namespace SplitWise.Entities
{
    public class Borrower
    {
        public Borrower(string borrowedBy,double amount)
        {
            BorrowedBy = borrowedBy;
            Amount = amount;
        }

        public string BorrowedBy { get; }
        public double Amount { get; }
    }
}

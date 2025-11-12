using Finance_Tracking.Domain.Enums;

namespace Finance_Tracking.Domain.Entities
{
    internal class Transaction
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Sum { get; set; }
        public TransactionType TransactionType { get; set; }
        public string Description { get; set; }

        public Transaction(int id, DateTime date, decimal sum, TransactionType transactionType, string description)
        {
            Id = id;
            Date = date;
            Sum = sum;
            TransactionType = transactionType;
            Description = description;
        }

        public Transaction() { }
    }
}

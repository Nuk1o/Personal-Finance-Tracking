using Finance_Tracking.Domain.Enums;

namespace Finance_Tracking.Domain.Entities
{
    internal class Wallet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Currency Currency { get; set; }
        public decimal BaseBalance { get; set; }
        public Transaction[] Transactions { get; set; }

        public Wallet(int id, string name, Currency currency, decimal baseBalance, Transaction[] transactions)
        {
            Id = id;
            Name = name;
            Currency = currency;
            BaseBalance = baseBalance;
            Transactions = transactions;
        }

        public Wallet() { }
    }
}

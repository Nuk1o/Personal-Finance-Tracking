using Finance_Tracking.Application.Interfaces;
using Finance_Tracking.Domain.Entities;
using Finance_Tracking.Domain.Enums;
using Finance_Tracking.Infrastructure.Services;
using Moq;

[TestClass]
public class WalletServiceTests
{
    [TestMethod]
    public void GetBalance_FirstWallet_ReturnsCorrectBalance()
    {
        var testWallet = new Wallet(
            id: 0,
            name: "Main Wallet",
            currency: Currency.RUB,
            baseBalance: 100,
            transactions: Array.Empty<Transaction>()
        );

        var transactions = new List<Transaction>
            {
                new Transaction(1,DateTime.Now, 50, TransactionType.Income,  "Salary"),
                new Transaction(2,DateTime.Now, 30, TransactionType.Expense,  "Groceries"),
                new Transaction(3, DateTime.Now, 20, TransactionType.Income, "Freelance")
            };

        var walletRepository = new TestWalletRepository(testWallet);
        var transactionRepository = new TestTransactionRepository(transactions);

        var walletService = new WalletService(walletRepository, transactionRepository);

        var result = walletService.GetBalance();

        Assert.AreEqual(140, result);
    }

    internal class TestWalletRepository : IWalletRepository
    {
        private readonly Wallet _wallet;
        public TestWalletRepository(Wallet wallet) => _wallet = wallet;
        public Wallet GetWallet() => _wallet;
    }

    internal class TestTransactionRepository : ITransactionRepository
    {
        private readonly List<Transaction> _transactions;
        public TestTransactionRepository(List<Transaction> transactions) => _transactions = transactions;

        public IEnumerable<Transaction> GetAll() => _transactions;

        public void Add(Transaction transaction) { }
        public IEnumerable<Transaction> GetByPeriod(DateTime start, DateTime end) =>
            throw new NotImplementedException();

        public void CreateTransaction(Transaction transaction)
        {
            throw new NotImplementedException();
        }

        public int GetLastTransactionID()
        {
            throw new NotImplementedException();
        }
    }
}

using Finance_Tracking.Domain.Entities;
using Finance_Tracking.Infrastructure.Repositories;
using Finance_Tracking.Infrastructure.Services;
using Finance_Tracking.Domain.Enums;

var transactions = GetTransactions();
var wallet = GetWallet(transactions);
var transactionRepository = new TransactionRepository(transactions);
var walletRepository = new WalletRepository(wallet);
var walletService = new WalletService(walletRepository,transactionRepository);

Console.WriteLine($"Current balance: {walletService.GetBalance()}");

List<Transaction> GetTransactions()
{
    var transactions = new List<Transaction>();
    transactions.Add(new Transaction(0, DateTime.Now, 100, TransactionType.Income, "test trans 1"));
    transactions.Add(new Transaction(1, DateTime.Now, 50, TransactionType.Expense, "test trans 2"));
    return transactions;
}

Wallet GetWallet(List<Transaction> transactions)
{
    var wallet = new Wallet(0, "TestUser", Currency.RUB, 200, transactions.ToArray());
    return wallet;
}


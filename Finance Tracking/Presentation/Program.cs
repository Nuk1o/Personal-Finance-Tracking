using Finance_Tracking.Domain.Entities;
using Finance_Tracking.Domain.Enums;
using Finance_Tracking.Infrastructure.Repositories;
using Finance_Tracking.Infrastructure.Services;

var transactions = GetTransactions();
var wallet = GetWallet(transactions);
var transactionRepository = new TransactionRepository(transactions);
var transactionService = new TransactionService(transactionRepository);
var walletRepository = new WalletRepository(wallet);
var walletService = new WalletService(walletRepository, transactionRepository);

ShowOptions();

void ShowOptions()
{
    Console.WriteLine($"0 - GetCurrent balance \n1 - New transaction\n2 - GetPeriodTransactions\n3 - Exit");
    var option = Console.ReadLine();

    switch (option)
    {
        case "0":
            Console.WriteLine($"Current balance: {walletService.GetBalance()}");
            ShowOptions();
            break;
        case "1":
            CreateTransaction();
            break;
        case "2":
            Console.WriteLine($"GetPeriodTransactions: {walletService.GetBalance()}");
            ShowOptions();
            break;
        case "3":
            Environment.Exit(0);
            break;

        default:
            ShowOptions();
            return;
    }
}

void CreateTransaction()
{
    Console.WriteLine($"0 - Income \n1 - Expense");
    TransactionType transactionType = TransactionType.Income;
    if (int.TryParse(Console.ReadLine(), out int transactionTypeNumber))
    {
        if (transactionTypeNumber == 0 || transactionTypeNumber == 1)
        {
            transactionType = transactionTypeNumber == 0 ? TransactionType.Income : TransactionType.Expense;
        }
        else
        {
            Console.WriteLine("Invalid transaction type");
            CreateTransaction();
        }
    }
    else
    {
        Console.WriteLine("Invalid error");
        CreateTransaction();
    }

    Console.WriteLine($"Write sum");
    decimal sum = 0;

    if (decimal.TryParse(Console.ReadLine(), out sum))
    {
        if (sum < 0)
        {
            Console.WriteLine("Invalid number");
            CreateTransaction();
        }
    }

    Console.WriteLine($"Enter description");
    var description = Console.ReadLine();

    transactionService.CreateTransaction(sum,transactionType, description);
    ShowOptions();
}


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


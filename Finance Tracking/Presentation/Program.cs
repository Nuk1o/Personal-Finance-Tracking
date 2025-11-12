using Finance_Tracking.Domain.Entities;
using Finance_Tracking.Domain.Enums;
using Finance_Tracking.Infrastructure.Repositories;
using Finance_Tracking.Infrastructure.Services;
using System;
using System.Text.Json;

Wallet wallet;

using (FileStream fs = new FileStream("userWallet.json", FileMode.OpenOrCreate))
{
    wallet = await JsonSerializer.DeserializeAsync<Wallet>(fs);
    Console.WriteLine($"UserWallet: {wallet.Id} | {wallet.Name}");
}

var transactions = GetTransactions();

var transactionRepository = new TransactionRepository(transactions);
var walletRepository = new WalletRepository(wallet);
var walletService = new WalletService(walletRepository, transactionRepository);
var transactionService = new TransactionService(transactionRepository, walletService);

//using (FileStream fs = new FileStream("userWallet.json", FileMode.OpenOrCreate))
//{
//    await JsonSerializer.SerializeAsync<Wallet>(fs, wallet);
//    Console.WriteLine("Data has been saved to file");
//}

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
            var range = GetValidDateRange();
            ShowPeriodTransactions(transactionService.GetByPeriodTransaction(range.start, range.end));
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

void ShowPeriodTransactions(IEnumerable<Transaction> transactions)
{
    var group = transactions.GroupBy(t => t.TransactionType);
    foreach (var transactionGroup in group.OrderByDescending(g => g.Sum(s => s.Sum)))
    {
        Console.WriteLine(transactionGroup.Key);
        Console.WriteLine($"| {transactionGroup.Sum(s => s.Sum)}");

        foreach (var transaction in transactionGroup)
        {
            Console.WriteLine($"Transaction : {transaction.Date} | {transaction.Sum} ");
        }
        Console.WriteLine();
    }
}

(DateTime start, DateTime end) GetValidDateRange()
{
    DateTime start, end = new DateTime();
    Console.WriteLine("Enter the date range in the format: DD.MM.YYYY-DD.MM.YYYY");
    var inputDates = Console.ReadLine();
    var dates = inputDates.Split(new char[] { '-' });
    if (!DateTime.TryParse(dates[0], out start) || !DateTime.TryParse(dates[1], out end))
    {
        GetValidDateRange();
    }
    if (end.Date > DateTime.Now)
    {
        GetValidDateRange();
    }
    if (start.Date> end.Date) 
    {
        GetValidDateRange();
    }
    return (start.Date, end.Date);
}

TransactionType GetValidTransactionType()
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
            GetValidTransactionType();
        }
    }
    else
    {
        Console.WriteLine("Invalid error");
        GetValidTransactionType();
    }

    return transactionType;
}

void CreateTransaction()
{
    var transactionType = GetValidTransactionType();

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
    transactions.Add(new Transaction(0, new DateTime(2025, 10, 15), 100, TransactionType.Income, "test trans 1"));
    transactions.Add(new Transaction(1, new DateTime(2025, 10, 20), 50, TransactionType.Expense, "test trans 2"));
    transactions.Add(new Transaction(2, new DateTime(2025, 11, 1), 75, TransactionType.Income, "test trans 3"));
    transactions.Add(new Transaction(3, new DateTime(2025, 11, 12), 25, TransactionType.Expense, "test trans 4"));
    return transactions;
}

Wallet GetWallet(List<Transaction> transactions)
{
    var wallet = new Wallet(0, "TestUser", Currency.RUB, 200, transactions.ToArray());
    return wallet;
}
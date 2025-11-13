using Finance_Tracking.Domain.Entities;
using Finance_Tracking.Domain.Enums;
using Finance_Tracking.Infrastructure.Repositories;
using Finance_Tracking.Infrastructure.Services;
using System.Text.Json;

Wallet currentWallet;
Wallet[] wallets;

using (FileStream fs = new FileStream("userWallets.json", FileMode.OpenOrCreate))
{
    wallets = await JsonSerializer.DeserializeAsync<Wallet[]>(fs);
    Console.WriteLine($"Wallets: {wallets.Length}");
    PrintWallets(wallets);
}

void PrintWallets(Wallet[]? wallets)
{
    foreach (Wallet wallet in wallets)
    {
        Console.WriteLine($"|ID {wallet.Id} | {wallet.Name} | {wallet.BaseBalance} | {wallet.Currency}");
    }
}

SelectWallet();

var transactions = currentWallet.Transactions;
var transactionRepository = new TransactionRepository(transactions);
var walletRepository = new WalletRepository(currentWallet);
var walletService = new WalletService(walletRepository, transactionRepository);
var transactionService = new TransactionService(transactionRepository, walletService);

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

    if(transactions != null)
    {
        Console.WriteLine("| Largest Expenses |");
        var expenses = transactions.Where(t => t.TransactionType == TransactionType.Expense).OrderByDescending(t => t.Sum).Take(3).ToList();
        foreach (var expense in expenses)
        {
            Console.WriteLine($"Transaction : {expense.Date} | {expense.Sum} ");
        }
        Console.WriteLine();
    }    
}

void SelectWallet()
{
    Console.WriteLine($"Select a wallet ID:");
    int idWallet = 0;

    if (!int.TryParse(Console.ReadLine(), out idWallet))
    {
        SelectWallet();
        return;
    }
    if (idWallet < 0 || idWallet > wallets.Length - 1)
    {
        SelectWallet();
        return;
    }
    currentWallet = wallets[idWallet];
}

(DateTime start, DateTime end) GetValidDateRange()
{
    DateTime start, end = new DateTime();
    Console.WriteLine("Enter the date range in the format: DD.MM.YYYY-DD.MM.YYYY");
    var inputDates = Console.ReadLine();
    var dates = inputDates.Split(new char[] { '-' });
    if (dates.Length != 2)
    {
        GetValidDateRange();
        return (DateTime.MinValue, DateTime.MinValue);
    }
    if (!DateTime.TryParse(dates[0], out start) || !DateTime.TryParse(dates[1], out end))
    {
        GetValidDateRange();
        return (DateTime.MinValue, DateTime.MinValue);
    }
    if (end.Date > DateTime.Now)
    {
        GetValidDateRange();
        return (DateTime.MinValue, DateTime.MinValue);
    }
    if (start.Date > end.Date)
    {
        GetValidDateRange();
        return (DateTime.MinValue, DateTime.MinValue);
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
            return;
        }
        if (sum > walletService.GetBalance() && transactionType == TransactionType.Expense)
        {
            Console.WriteLine("Insufficient funds");
            CreateTransaction();
            return;
        }
    }
    else
    {
        Console.WriteLine("Invalid number");
        CreateTransaction();
        return;
    }

    Console.WriteLine($"Enter description");
    var description = Console.ReadLine();

    transactionService.CreateTransaction(sum, transactionType, description);
    ShowOptions();
}

Wallet GetWallet(List<Transaction> transactions)
{
    var wallet = new Wallet(0, "TestUser", Currency.RUB, 200, transactions.ToArray());
    return wallet;
}
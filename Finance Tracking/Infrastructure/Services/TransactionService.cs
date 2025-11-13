using Finance_Tracking.Application.Interfaces;
using Finance_Tracking.Domain.Entities;
using Finance_Tracking.Domain.Enums;

namespace Finance_Tracking.Infrastructure.Services
{
    internal class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IWalletService _walletService;
        private int _currentTransactionID;

        public TransactionService(ITransactionRepository transactionRepository, IWalletService walletService)
        {
            _transactionRepository = transactionRepository;
            _currentTransactionID = transactionRepository.GetLastTransactionID();
            _walletService = walletService;
        }

        public void CreateTransaction(decimal sum, TransactionType type, string description)
        {
            if (type == TransactionType.Expense && _walletService.GetBalance() < sum)
            {
                return;
            }
            _currentTransactionID++;
            var transaction = new Transaction(_currentTransactionID, DateTime.Now, sum, type, description);
            _transactionRepository.CreateTransaction(transaction);
        }

        public IEnumerable<Transaction> GetByPeriodTransaction(DateTime startDate, DateTime endDate)
        {
            var transactions = _transactionRepository.GetByPeriod(startDate, endDate);
            return transactions;
        }
    }
}

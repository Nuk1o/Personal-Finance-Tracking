using Finance_Tracking.Application.Interfaces;
using Finance_Tracking.Domain.Entities;
using Finance_Tracking.Domain.Enums;

namespace Finance_Tracking.Infrastructure.Services
{
    internal class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        private int _currentTransactionID;

        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
            _currentTransactionID = transactionRepository.GetLastTransactionID();
        }

        public void CreateTransaction(decimal sum, TransactionType type, string description)
        {
            _currentTransactionID++;
            var transaction = new Transaction(_currentTransactionID,DateTime.Now,sum,type,description);
            _transactionRepository.CreateTransaction(transaction);
        }
    }
}

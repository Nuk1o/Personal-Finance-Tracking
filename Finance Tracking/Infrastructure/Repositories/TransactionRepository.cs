using Finance_Tracking.Application.Interfaces;
using Finance_Tracking.Domain.Entities;

namespace Finance_Tracking.Infrastructure.Repositories
{
    internal class TransactionRepository : ITransactionRepository
    {
        private readonly List<Transaction> _transactions;

        public TransactionRepository(List<Transaction> transaction) => _transactions = transaction;

        public IEnumerable<Transaction> GetAll() => _transactions;

        public IEnumerable<Transaction> GetByPeriod(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public void CreateTransaction(Transaction transaction)
        {
            _transactions.Add(transaction);
        }

        public int GetLastTransactionID()
        {
            return _transactions.Max(t => t.Id);
        }
    }
}

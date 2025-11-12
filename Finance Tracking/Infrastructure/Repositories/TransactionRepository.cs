using Finance_Tracking.Application.Interfaces;
using Finance_Tracking.Domain.Entities;

namespace Finance_Tracking.Infrastructure.Repositories
{
    internal class TransactionRepository : ITransactionRepository
    {
        private readonly List<Transaction> _transactions;

        public TransactionRepository(List<Transaction> transaction) 
            => _transactions = transaction;

        public IEnumerable<Transaction> GetAll() 
            => _transactions;

        public IEnumerable<Transaction> GetByPeriod(DateTime startDate, DateTime endDate) 
            => _transactions.Where(t => t.Date.Date >= startDate.Date && t.Date.Date <= endDate.Date);

        public void CreateTransaction(Transaction transaction) 
            => _transactions.Add(transaction);

        public int GetLastTransactionID() 
            => _transactions.Max(t => t.Id);
    }
}

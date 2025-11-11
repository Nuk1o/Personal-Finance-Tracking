using Finance_Tracking.Application.Interfaces;
using Finance_Tracking.Domain.Entities;

namespace Finance_Tracking.Infrastructure.Repositories
{
    internal class TransactionRepository : ITransactionRepository
    {
        private readonly IEnumerable<Transaction> _transactions;

        public TransactionRepository(IEnumerable<Transaction> transaction) => _transactions = transaction;

        public IEnumerable<Transaction> GetAll() => _transactions;

        public IEnumerable<Transaction> GetByPeriod(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }
    }
}

using Finance_Tracking.Domain.Entities;
using Finance_Tracking.Domain.Enums;

namespace Finance_Tracking.Application.Interfaces
{
    internal interface ITransactionRepository
    {
        IEnumerable<Transaction> GetAll();
        IEnumerable<Transaction> GetByPeriod(DateTime startDate, DateTime endDate);
        void CreateTransaction(Transaction transaction);
        int GetLastTransactionID();
    }
}

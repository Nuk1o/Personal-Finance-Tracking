using Finance_Tracking.Domain.Entities;

namespace Finance_Tracking.Application.Interfaces
{
    internal interface ITransactionRepository
    {
        IEnumerable<Transaction> GetAll();
        IEnumerable<Transaction> GetByPeriod(DateTime startDate, DateTime endDate);
    }
}

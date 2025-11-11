using Finance_Tracking.Domain.Entities;
using Finance_Tracking.Domain.Enums;

namespace Finance_Tracking.Application.Interfaces
{
    internal interface ITransactionService
    {
        void CreateTransaction(decimal sum, TransactionType type, string description);
    }
}

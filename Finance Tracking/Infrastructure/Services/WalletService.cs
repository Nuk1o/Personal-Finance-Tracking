using Finance_Tracking.Application.Interfaces;
using Finance_Tracking.Domain.Enums;

namespace Finance_Tracking.Infrastructure.Services
{
    internal class WalletService : IWalletService
    {
        private IWalletRepository _walletRepository;
        private ITransactionRepository _transactionRepository;

        public WalletService(IWalletRepository walletRepository, ITransactionRepository transactionRepository)
        {
            _walletRepository = walletRepository;
            _transactionRepository = transactionRepository;
        }

        public decimal GetBalance()
        {
            var balance = _walletRepository.GetWallet().BaseBalance;
            var transactions = _transactionRepository.GetAll();
            foreach (var transaction in transactions)
            {
                if (transaction.TransactionType == TransactionType.Income)
                    balance += transaction.Sum;
                else balance -= transaction.Sum;
            }
            return balance;
        }
    }
}

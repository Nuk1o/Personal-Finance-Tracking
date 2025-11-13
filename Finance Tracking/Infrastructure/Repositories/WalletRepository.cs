using Finance_Tracking.Application.Interfaces;
using Finance_Tracking.Domain.Entities;

namespace Finance_Tracking.Infrastructure.Repositories
{
    internal class WalletRepository : IWalletRepository
    {
        private readonly Wallet _wallet;
        public WalletRepository(Wallet wallet) => _wallet = wallet;
        public Wallet GetWallet() => _wallet;
    }
}

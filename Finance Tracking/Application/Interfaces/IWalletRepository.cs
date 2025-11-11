using Finance_Tracking.Domain.Entities;

namespace Finance_Tracking.Application.Interfaces
{
    internal interface IWalletRepository
    {
        Wallet GetWallet();
    }
}

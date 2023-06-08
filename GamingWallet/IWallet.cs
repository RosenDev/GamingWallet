namespace GamingWallet
{
    public interface IWallet
    {
        decimal CurrentBalance { get; }

        void Deposit(decimal amount);

        void Withdraw(decimal amount);

        void Bet(decimal amount);

        void AcceptWin(decimal amount);
    }
}

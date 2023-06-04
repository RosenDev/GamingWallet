namespace GamingWallet
{
    public interface IWallet
    {
        double CurrentBalance { get; }

        void Deposit(double amount);

        void Withdraw(double amount);

        void Bet(double amount);

        void AcceptWin(double amount);
    }
}

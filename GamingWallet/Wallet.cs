namespace GamingWallet
{
    public class Wallet : IWallet
    {
        public double CurrentBalance { get; private set; }

        public void Deposit(double amount)
        {
            if(amount < 0)
            {
                throw new ArgumentException(ErrorMessageConstants.LessThanZeroAmountErrorMessage);
            }

            CurrentBalance += amount;
        }

        public void Withdraw(double amount)
        {
            if(amount < 0)
            {
                throw new ArgumentException(ErrorMessageConstants.LessThanZeroAmountErrorMessage);
            }

            if(amount > CurrentBalance)
            {
                throw new InvalidOperationException(ErrorMessageConstants.CannotWithdrawMoreThanAvaiableBalance);
            }

            CurrentBalance -= amount;
        }

        public void Bet(double amount)
        {
            if(amount < 0)
            {
                throw new ArgumentException(ErrorMessageConstants.LessThanZeroAmountErrorMessage);
            }

            if(amount > CurrentBalance)
            {
                throw new InvalidOperationException(ErrorMessageConstants.CannotBetMoreThanAvaiableBalance);
            }

            CurrentBalance -= amount;
        }

        public void AcceptWin(double amount)
        {
            if(amount < 0)
            {
                throw new ArgumentException(ErrorMessageConstants.LessThanZeroAmountErrorMessage);
            }

            CurrentBalance += amount;
        }
    }
}

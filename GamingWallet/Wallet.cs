namespace GamingWallet
{
    public class Wallet : IWallet
    {
        public decimal CurrentBalance { get; private set; }

        public void Deposit(decimal amount)
        {
            if(amount < 0)
            {
                throw new ArgumentException(ErrorMessageConstants.LessThanZeroAmountErrorMessage);
            }

            CurrentBalance += amount;
        }

        public void Withdraw(decimal amount)
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

        public void Bet(decimal amount)
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

        public void AcceptWin(decimal amount)
        {
            if(amount < 0)
            {
                throw new ArgumentException(ErrorMessageConstants.LessThanZeroAmountErrorMessage);
            }

            CurrentBalance += amount;
        }
    }
}

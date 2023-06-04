namespace GamingWallet.Services
{
    public class SlotGameService : ISlotGameService
    {
        public double PlayWithAmount(double amount)
        {
            if(amount < 0)
            {
                throw new ArgumentException(ErrorMessageConstants.LessThanZeroAmountErrorMessage);
            }

            var random = new Random();
            int chance = random.Next(1, 101);

            if(chance >= 50)
            {
                return 0;
            }
            else if(chance <= 40 && chance > 10)
            {
                return amount * 2;
            }
            else
            {
                var mutiplier = random.Next(2, 11);

                return amount * mutiplier;
            }
        }
    }
}

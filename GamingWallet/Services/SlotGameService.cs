namespace GamingWallet.Services
{
    public class SlotGameService : ISlotGameService
    {
        private readonly Random random = new Random();
        public decimal PlayWithAmount(decimal amount)
        {
            if(amount < 0)
            {
                throw new ArgumentException(ErrorMessageConstants.LessThanZeroAmountErrorMessage);
            }
            int chance = random.Next(GameConstants.OverallChanceMin, GameConstants.OverallChanceMin);

            if(chance >= GameConstants.ChanceOfLose)
            {
                return 0;
            }
            else if(chance <= GameConstants.ChanceOfDoubledWinMax && chance > GameConstants.ChanceOfDoubledWinMin)
            {
                return amount * GameConstants.DefaultMultiplier;
            }
            else
            {
                var mutiplier = random.Next(GameConstants.AdvancedMutiplierMin, GameConstants.AdvancedMutiplierMax);

                return amount * mutiplier;
            }
        }
    }
}

using FluentAssertions;
using GamingWallet.Services;

namespace GamingWallet.Tests
{
    public class SlotGameServiceTests
    {
        [Fact]
        public void PlayWithAmountShouldReturnGameResultWhenAmountIsPositiveNumber()
        {
            var slotGameService = new SlotGameService();

            slotGameService.PlayWithAmount(10).Should().BeGreaterThan(-1);
        }

        [Fact]
        public void PlayWithAmountShouldThrowWhenAmountIsNegativeNumber()
        {
            var slotGameService = new SlotGameService();

            Assert.Throws<ArgumentException>(() => slotGameService.PlayWithAmount(-1));
        }
    }
}

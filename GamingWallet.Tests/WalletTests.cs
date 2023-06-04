using FluentAssertions;

namespace GamingWallet.Tests
{
    public class WalletTests
    {
        [Fact]
        public void DepositShouldIncreaseCurrentBalanceWhenAmountIsPositiveNumber()
        {
            var expectedBalance = 25;
            var wallet = new Wallet();

            wallet.Deposit(10);
            wallet.Deposit(15);

            wallet.CurrentBalance.Should().Be(expectedBalance);
        }

        [Fact]
        public void DepositShouldThrowExcpetionWhenAmountIsNegativeNumber()
        {
            var wallet = new Wallet();

            Assert.Throws<ArgumentException>(() => wallet.Deposit(-1));
        }

        [Fact]
        public void WithdrawShouldDecreaseCurrentBalanceWhenAmountIsPositiveNumberAndDoNotExceedCurrentBalance()
        {
            var expectedBalance = 5;
            var wallet = new Wallet();

            wallet.Deposit(10);
            wallet.Withdraw(5);

            wallet.CurrentBalance.Should().Be(expectedBalance);
        }

        [Fact]
        public void WithdrawShouldThrowExcpetionWhenAmountIsNegativeNumber()
        {
            var wallet = new Wallet();

            Assert.Throws<ArgumentException>(() => wallet.Withdraw(-1));
        }

        [Fact]
        public void WithdrawShouldThrowExcpetionWhenAmountExceedCurrentBalance()
        {
            var wallet = new Wallet();

            Assert.Throws<InvalidOperationException>(() => wallet.Withdraw(10));
        }

        [Fact]
        public void BetShouldDecreaseCurrentBalanceWhenAmountIsPositiveNumberAndDoNotExceedCurrentBalance()
        {
            var expectedBalance = 5;
            var wallet = new Wallet();

            wallet.Deposit(10);
            wallet.Bet(5);

            wallet.CurrentBalance.Should().Be(expectedBalance);
        }

        [Fact]
        public void BetShouldThrowExcpetionWhenAmountIsNegativeNumber()
        {
            var wallet = new Wallet();

            Assert.Throws<ArgumentException>(() => wallet.Bet(-1));
        }

        [Fact]
        public void BetShouldThrowExcpetionWhenAmountExceedCurrentBalance()
        {
            var wallet = new Wallet();

            Assert.Throws<InvalidOperationException>(() => wallet.Bet(10));
        }

        [Fact]
        public void AcceptWinShouldIncreaseCurrentBalanceWhenAmountIsPositiveNumber()
        {
            var expectedBalance = 10;
            var wallet = new Wallet();

            wallet.AcceptWin(10);

            wallet.CurrentBalance.Should().Be(expectedBalance);
        }

        [Fact]
        public void AcceptWinShouldThrowExcpetionWhenAmountIsNegativeNumber()
        {
            var wallet = new Wallet();

            Assert.Throws<ArgumentException>(() => wallet.AcceptWin(-1));
        }
    }
}
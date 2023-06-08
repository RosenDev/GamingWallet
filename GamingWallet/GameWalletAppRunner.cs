using GamingWallet.Services;

namespace GamingWallet
{
    public class GameWalletAppRunner : IAppRunner
    {
        private readonly IWallet wallet;
        private readonly IOutputProviderService outputProviderService;
        private readonly IInputProviderService inputProviderService;
        private readonly ISlotGameService slotGameService;

        public GameWalletAppRunner(
            IWallet wallet,
            IOutputProviderService outputProvider,
            IInputProviderService inputProvider,
            ISlotGameService slotGameService)
        {
            this.wallet = wallet;
            this.outputProviderService = outputProvider;
            this.inputProviderService = inputProvider;
            this.slotGameService = slotGameService;
        }

        public void Run()
        {
            var operation = string.Empty;

            do
            {
                try
                {
                    outputProviderService.WriteLine("Please submit action:");
                    var operationWithParams = inputProviderService.ReadLine()!.Split(" ");
                    operation = operationWithParams[0];

                    if(operation == "deposit")
                    {
                        if(operationWithParams.Length == 1)
                        {
                            outputProviderService.WriteLine("Amount is required!");
                            continue;
                        }

                        if(!decimal.TryParse(operationWithParams[1], out decimal amount))
                        {
                            outputProviderService.WriteLine(ErrorMessageConstants.InvalidNumberErrorMessage);
                            continue;
                        }

                        wallet.Deposit(amount);

                        outputProviderService.WriteLine($"Your deposit of {amount} was succesfull. Your current balance is ${wallet.CurrentBalance}");
                    }
                    else if(operation == "withdraw")
                    {
                        if(operationWithParams.Length == 1)
                        {
                            outputProviderService.WriteLine("Amount is required!");
                            continue;
                        }

                        if(!decimal.TryParse(operationWithParams[1], out decimal amount))
                        {
                            outputProviderService.WriteLine(ErrorMessageConstants.InvalidNumberErrorMessage);
                            continue;
                        }

                        wallet.Withdraw(amount);
                        outputProviderService.WriteLine($"Your withdrawal of {amount} was succesfull. Your current balance is ${wallet.CurrentBalance}");
                    }
                    else if(operation == "bet")
                    {
                        if(operationWithParams.Length == 1)
                        {
                            outputProviderService.WriteLine("Amount is required!");
                            continue;
                        }

                        if(!decimal.TryParse(operationWithParams[1], out decimal amount))
                        {
                            outputProviderService.WriteLine(ErrorMessageConstants.InvalidNumberErrorMessage);
                            continue;
                        }

                        if(amount < 1 || amount > 10)
                        {
                            outputProviderService.WriteLine("The amount should be between $1 and $10!");
                            continue;
                        }

                        wallet.Bet(amount);

                        var win = slotGameService.PlayWithAmount(amount);

                        if(win > 0)
                        {
                            wallet.AcceptWin(win);
                            outputProviderService.WriteLine($"Congrats - you won ${win}! Your current balance is: ${wallet.CurrentBalance}");
                        }
                        else
                        {
                            outputProviderService.WriteLine($"No luck this time! Your current balance is: ${wallet.CurrentBalance}");
                        }
                    }
                }
                catch(Exception ex)
                {
                    outputProviderService.WriteLine(ex.Message);
                }

            } while(operation != "exit");

            outputProviderService.WriteLine("Thank you for playing! Hope to see you again soon.");
        }
    }
}

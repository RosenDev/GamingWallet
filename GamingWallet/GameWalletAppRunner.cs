using GamingWallet.Services;

namespace GamingWallet
{
    public class GameWalletAppRunner : IAppRunner
    {
        private readonly IWallet wallet;
        private readonly ISlotGameService slotGameService;

        public GameWalletAppRunner(IWallet wallet, ISlotGameService slotGameService)
        {
            this.wallet = wallet;
            this.slotGameService = slotGameService;
        }

        public void Run()
        {
            var operation = string.Empty;

            do
            {
                try
                {
                    Console.WriteLine("Please submit action:");
                    var operationWithParams = Console.ReadLine().Split(" ");
                    operation = operationWithParams[0];

                    if(operation == "deposit")
                    {
                        if(operationWithParams.Length == 1)
                        {
                            Console.WriteLine("Amount is required!");
                            continue;
                        }

                        if(!double.TryParse(operationWithParams[1], out double amount))
                        {
                            Console.WriteLine(ErrorMessageConstants.InvalidNumberErrorMessage);
                            continue;
                        }

                        wallet.Deposit(amount);

                        Console.WriteLine($"Your deposit of {amount} was succesfull. Your current balance is ${wallet.CurrentBalance}");
                    }
                    else if(operation == "withdraw")
                    {
                        if(operationWithParams.Length == 1)
                        {
                            Console.WriteLine("Amount is required!");
                            continue;
                        }

                        if(!double.TryParse(operationWithParams[1], out double amount))
                        {
                            Console.WriteLine(ErrorMessageConstants.InvalidNumberErrorMessage);
                            continue;
                        }

                        wallet.Withdraw(amount);
                        Console.WriteLine($"Your withdrawal of {amount} was succesfull. Your current balance is ${wallet.CurrentBalance}");
                    }
                    else if(operation == "bet")
                    {
                        if(operationWithParams.Length == 1)
                        {
                            Console.WriteLine("Amount is required!");
                            continue;
                        }

                        if(!double.TryParse(operationWithParams[1], out double amount))
                        {
                            Console.WriteLine(ErrorMessageConstants.InvalidNumberErrorMessage);
                            continue;
                        }

                        if(amount < 1 || amount > 10)
                        {
                            Console.WriteLine("The amount should be between $1 and $10!");
                            continue;
                        }

                        wallet.Bet(amount);

                        var win = slotGameService.PlayWithAmount(amount);

                        if(win > 0)
                        {
                            wallet.AcceptWin(win);
                            Console.WriteLine($"Congrats - you won ${win}! Your current balance is: ${wallet.CurrentBalance}");
                        }
                        else
                        {
                            Console.WriteLine($"No luck this time! Your current balance is: ${wallet.CurrentBalance}");
                        }
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            } while(operation != "exit");

            Console.WriteLine("Thank you for playing! Hope to see you again soon.");
        }
    }
}

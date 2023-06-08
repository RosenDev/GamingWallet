namespace GamingWallet.Services
{
    public class ConsoleOutputProviderService : IOutputProviderService
    {
        public void WriteLine(object message)
        {
            Console.WriteLine(message);
        }
    }
}

namespace GamingWallet.Services
{
    public class ConsoleInputProviderService : IInputProviderService
    {
        public string? ReadLine()
        {
            return Console.ReadLine();
        }
    }
}

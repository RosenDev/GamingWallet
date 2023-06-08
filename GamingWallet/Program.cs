using GamingWallet;
using GamingWallet.Services;
using Microsoft.Extensions.DependencyInjection;

IServiceProvider serviceProvider = new ServiceCollection()
    .AddSingleton<IWallet, Wallet>()
    .AddSingleton<ISlotGameService, SlotGameService>()
    .AddSingleton<IAppRunner, GameWalletAppRunner>()
    .AddSingleton<IInputProviderService, ConsoleInputProviderService>()
    .AddSingleton<IOutputProviderService, ConsoleOutputProviderService>()
    .BuildServiceProvider();

var appRunner = serviceProvider.GetRequiredService<IAppRunner>();

appRunner.Run();


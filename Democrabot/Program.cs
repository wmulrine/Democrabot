using Democrabot.Logic;
using Democrabot.Modules;
using Democrabot.Services;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TextCommandFramework.Services;

internal class Program
{
    public static async Task Main(string[] args)
    {
        var discordToken = Environment.GetEnvironmentVariable("DiscordAPI");
        await using var services = ConfigureServices();
        var client = services.GetRequiredService<DiscordSocketClient>();
        await services.GetRequiredService<CommandHandlingService>().InitializeAsync();
        client.Log += Logger.Log;

        client.MessageReceived += ClientReader.ClientOnMessageReceived;

        client.Ready += () =>
        {
            Console.WriteLine("Bot is connected!");
            return Task.CompletedTask;
        };

        await client.LoginAsync(TokenType.Bot, discordToken);
        await client.StartAsync();
        await Task.Delay(Timeout.Infinite);
    }

    private static ServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection()
            .AddSingleton(new DiscordSocketConfig
            {
                GatewayIntents = GatewayIntents.AllUnprivileged | GatewayIntents.MessageContent
            })
            .AddSingleton<DiscordSocketClient>()
            .AddSingleton<CommandService>()
            .AddSingleton<ApiModule>()
            .AddSingleton<CommandHandlingService>();


        services.AddHttpClient<FlyDevService>(c => c.BaseAddress = new Uri("https://helldivers-2.fly.dev"));
        return services.BuildServiceProvider();

    }
}
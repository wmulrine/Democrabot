using Discord;
using Discord.WebSocket;

internal class Program
{
    private static DiscordSocketClient? _client;

    public static async Task Main(string[] args)
    {
        var discordToken = Environment.GetEnvironmentVariable("DiscordAPI");
        _client = new DiscordSocketClient();

        _client.Log += Log;

        await _client.LoginAsync(TokenType.Bot, discordToken);
        await _client.StartAsync();

        await Task.Delay(-1);
    }

    private static Task Log(LogMessage msg)
    {
        Console.WriteLine(msg.ToString());
        return Task.CompletedTask;
    }
}
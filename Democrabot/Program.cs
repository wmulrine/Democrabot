using Discord;
using Discord.WebSocket;

internal class Program
{
    private static DiscordSocketClient? _client;

    public static async Task Main(string[] args)
    {
        var discordToken = Environment.GetEnvironmentVariable("DiscordAPI");

        var config = new DiscordSocketConfig
        {
            GatewayIntents = GatewayIntents.AllUnprivileged | GatewayIntents.MessageContent
        };
        _client = new DiscordSocketClient(config);

        _client.Log += Log;

        _client.MessageReceived += ClientOnMessageReceived;
        _client.Ready += () =>
        {
            Console.WriteLine("Bot is connected!");
            return Task.CompletedTask;
        };

        await _client.LoginAsync(TokenType.Bot, discordToken);
        await _client.StartAsync();
        await Task.Delay(Timeout.Infinite);
    }
    private static async Task ClientOnMessageReceived(SocketMessage socketMessage)
    {
        await Task.Run(() =>
        {
            //Activity is not from a Bot.
            if (!socketMessage.Author.IsBot)
            {

                var authorId = socketMessage.Author.Id;
                var channelId = socketMessage.Channel.Id.ToString();
                var messageId = socketMessage.Id.ToString();
                var message = socketMessage.Content;
                if (message.Contains("democracy", StringComparison.CurrentCultureIgnoreCase))
                {
                    var channel = _client.GetChannel(Convert.ToUInt64(channelId));
                    var socketChannel = (ISocketMessageChannel)channel;
                    var salute = new Emoji("🫡");

                }
            }
        });
    }

    private static Task Log(LogMessage msg)
    {
        Console.WriteLine(msg.ToString());
        return Task.CompletedTask;
    }
}
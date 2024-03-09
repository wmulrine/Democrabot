using Democrabot.Services;
using Discord;
using Discord.WebSocket;

namespace Democrabot.Logic
{
    internal static class ClientReader
    {
        internal static async Task ClientOnMessageReceived(SocketMessage socketMessage)
        {
            await Task.Run(async () =>
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
                        var salute = new Emoji("🫡");
                        await socketMessage.AddReactionAsync(salute);
                    }
                    if (message.Contains("money", StringComparison.CurrentCultureIgnoreCase))
                    {
                        var salute = new Emoji("🤑");
                        await socketMessage.AddReactionAsync(salute);
                    }
                }
            });
        }
    }
}

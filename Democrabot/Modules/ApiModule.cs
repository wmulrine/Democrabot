using Democrabot.Services;
using Discord.Commands;

namespace Democrabot.Modules
{
    internal class ApiModule : ModuleBase<SocketCommandContext>
    {
        public required FlyDevService FlyDevService { get; set; }

        [Command("what is the season")]
        public async Task GetSeasonAsync()
        {
            var season = await FlyDevService.GetCurrentSeason();

            await ReplyAsync(season);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;

namespace DiscordTestBot.Modules
{
    public class Misc : ModuleBase<SocketCommandContext>
    {
        Random random = new Random();

        [Command("zucc")]
        public async Task Zucc()
        {
            await Context.Channel.SendMessageAsync("Give me your data");
        }

        [Command("echo")]
        public async Task Echo([Remainder]string message)
        {
            var embed = new EmbedBuilder();
            embed.WithTitle("Echoed message");
            embed.WithDescription(message);
            embed.WithColor(new Color(0, 255, 0));

            await Context.Channel.SendMessageAsync("", false, embed);
        }


        string[] dice = new string[] { "<:d4:519512976986996756>",
                                        "<:d6:519512976995123211>",
                                        "<:d8:519512980589641728>",
                                        "<:d10:519512977305632777>",
                                        "<:d12:519512977460953088>",
                                        "<:d20:519512980816134144>"};

        [Command("die")]
        public async Task DieEmoji()
        {
            await Context.Channel.SendMessageAsync(dice[random.Next(0, dice.Length)]);
        }
    }
}

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


        string[] dice = new string[] { "<:d4:521170605484015616>",
                                        "<:d6:521170605488209923>",
                                        "<:d8:521170608482942996>",
                                        "<:d10:521170607531098113>",
                                        "<:d12:521170607547875339>",
                                        "<:d20:521170608944316456>" };

        [Command("die")]
        public async Task DieEmoji()
        {
            await Context.Channel.SendMessageAsync(dice[random.Next(0, dice.Length)]);
        }
    }
}

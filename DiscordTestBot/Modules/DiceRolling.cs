using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;

namespace DiscordTestBot.Modules
{
    public class DiceRolling : ModuleBase<SocketCommandContext>
    {
        private Random random = new Random();

        [Command("d20")]
        public async Task RollD20()
        {
            int roll = random.Next(1, 20);
            if (roll == 1)
            {
                await Context.Channel.SendMessageAsync(roll.ToString() + " CRITICAL MISS :laughing:");
            }
            else if (roll == 20)
            {
                await Context.Channel.SendMessageAsync(roll.ToString() + " CRITIAL HIT :scream:");
            }
            else
            {
                await Context.Channel.SendMessageAsync(roll.ToString());
            }
        }

        [Command("roll")]
        public async Task RollDice([Remainder]string diceRollString)
        {
            List<int> diceRolls = new List<int>();
            do {
                diceRollString.Trim();
                string numDiceString;
                string diceNumString;
                int numDice;
                int diceNum;

                numDiceString = diceRollString.Substring(0, diceRollString.IndexOf('d'));
                diceRollString = diceRollString.Substring(diceRollString.IndexOf('d') +1);
                numDice = (numDiceString.Length > 0) ? Convert.ToInt32(numDiceString) : 1;

                // either there is a plus after the 'd' or its the end of the string
                if (diceRollString.Contains("+"))
                {
                    diceNumString = diceRollString.Substring(0, diceRollString.IndexOf('+'));
                    diceNumString.Trim();
                    diceRollString = diceRollString.Substring(diceRollString.IndexOf('+') +1);
                }
                else
                {
                    diceNumString = diceRollString;
                    diceRollString = "";
                }
                diceNum = Convert.ToInt32(diceNumString);

                for(int i=0; i<numDice; i++)
                {
                    diceRolls.Add(random.Next(1, diceNum));
                }

            } while (diceRollString.Length > 0);

            int sum = 0;
            string finalOutput = "You Rolled: ";
            foreach(int num in diceRolls)
            {
                sum += num;
                finalOutput += num + " ";
            }
            finalOutput += "\n Total: " + sum;
            await Context.Channel.SendMessageAsync(finalOutput);
        }
    }
}

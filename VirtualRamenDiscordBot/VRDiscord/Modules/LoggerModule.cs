using System;
using System.Threading.Tasks;
using Discord;
using Discord.Interactions;

namespace VRDiscord.Modules
{
    /// <summary>
    /// Handles reactions on messages that give roles.
    /// </summary>
    public class LoggerModule : InteractionModuleBase<SocketInteractionContext>
    {
        private static DiscordAPI _client;

        public LoggerModule(DiscordAPI socketClient)
        {
            _client = socketClient;
        }

        public static async Task Log(string message, IUser user = null)
        {
            Console.WriteLine(message);

            if (user != null)
            {
                await user.SendMessageAsync(message);
            }
        }
    }
}
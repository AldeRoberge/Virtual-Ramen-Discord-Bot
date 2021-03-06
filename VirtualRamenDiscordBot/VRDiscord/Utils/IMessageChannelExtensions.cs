using System.Threading.Tasks;
using Discord;

namespace VRDiscord.Utils
{
    public static class MessageChannelExtensions
    {
        // Delete all messages
        public static async Task DeleteAllMessages(this IMessageChannel channel)
        {
            await foreach (var message in channel.GetMessagesAsync().Flatten())
            {
                await message.DeleteAsync();
            }
        }
    }
}
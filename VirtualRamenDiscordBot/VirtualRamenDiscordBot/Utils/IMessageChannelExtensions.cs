﻿using System.Threading.Tasks;
using Discord;

namespace _04_interactions_framework.Utils
{
    public static class IMessageChannelExtensions
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
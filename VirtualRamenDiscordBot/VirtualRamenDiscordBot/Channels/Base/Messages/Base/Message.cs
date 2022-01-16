using System.Collections.Generic;
using Discord;

namespace VirtualRamenDiscordBot.Channels.Generators.Messages.Base
{
    /// <summary>
    /// An embed, text or image which can have emotes added to it.
    /// </summary>
    public class Message
    {
        public List<IEmote> Emotes = new List<IEmote>();

        public void AddEmote(params Emote[] emote)
        {
            Emotes.AddRange(emote);
        }

        public void AddEmote(IEnumerable<Emote> emote)
        {
            Emotes.AddRange(emote);
        }

        public void AddEmoji(params Emoji[] emoji)
        {
            Emotes.AddRange(emoji);
        }

        public void AddEmoji(IEnumerable<Emoji> emojis)
        {
            Emotes.AddRange(emojis);
        }

        public void AddEmoji(List<IEmote> emotes)
        {
            Emotes.AddRange(emotes);
        }
    }
}
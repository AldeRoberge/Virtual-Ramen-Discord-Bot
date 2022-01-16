using Discord;

namespace VirtualRamenDiscordBot.Channels.Roles.SelectableRoles.Base
{
    /// <summary>
    /// Loaded, using reflection, at runtime to create a message and emote reaction for the Roles Channel.
    /// </summary>
    public abstract class SelectableRole
    {
        public abstract string Name { get; }

        public abstract IEmote Emote { get; }
        public abstract EmbedBuilder EmbedBuilder { get; }

        public abstract string Role { get; }
    }
}
using VirtualRamenDiscordBot.Channels.Generators.Messages.Base;

namespace VirtualRamenDiscordBot.Channels.Generators.Base
{
    /// <summary>
    /// The base class for a ChannelGenerator, which must identify which Channel it is going to update,
    /// which ChannelsEnum this channel represents (allows to filter when using the command).
    /// Loaded by reflection in ChannelGeneratorModule.
    /// </summary>
    public abstract class ChannelGenerator
    {
        public abstract Channel Channel { get; }

        public abstract ChannelsEnum ChannelsEnum { get; }

        /// <summary>
        /// Passes messageContainer to be filled with Messages.
        /// </summary>
        public abstract void PopulateMessages(MessageContainer messageContainer);
    }
}
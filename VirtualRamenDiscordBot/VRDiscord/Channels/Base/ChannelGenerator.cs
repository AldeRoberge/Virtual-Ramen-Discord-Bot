using VRDiscord.Channels.Base.Messages.Base;

namespace VRDiscord.Channels.Base
{
    /// <summary>
    /// The base class for a ChannelGenerator, which must identify which Channel it is going to update,
    /// which ChannelsEnum this channel represents (allows to filter when using the command).
    /// Loaded by reflection in ChannelGeneratorModule.
    /// </summary>
    public abstract class ChannelGenerator
    {
        public abstract Channel Channel { get; }

        public abstract bool DeleteAllMessages { get; }

        /// <summary>
        /// Passes messageContainer to be filled with Messages.
        /// </summary>
        public abstract void PopulateMessages(MessageContainer messageContainer);
        
        
        
    }
}
namespace VRDiscord.Channels.Base
{
    /// <summary>
    /// Represents a Discord Text channel.
    /// Used for regeneration of a channel to update the channel's state.
    /// The only thing that may never change is the Id, which is used to identify the channel.
    /// </summary>
    public class Channel
    {
        public ulong Id;
        public string Name;
        public ChannelsEnum ChannelsEnum;

        /// <summary>
        /// The channel description (topic) shown at the top.
        /// </summary>
        public string Topic;
    }
}
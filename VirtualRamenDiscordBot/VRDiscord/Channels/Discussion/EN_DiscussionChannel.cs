using VRDiscord.Channels.Base;
using VRDiscord.Channels.Base.Messages.Base;

namespace VRDiscord.Channels.Discussion
{
    public class EN_DiscussionChannel : ChannelGenerator
    {
        public override bool DeleteAllMessages => false;
        
        public override Channel Channel => new()
        {
            Id = ChannelConstants.DiscussionEN,
            Name = "『🌍』𝐃𝐢𝐬𝐜𝐮𝐬𝐬𝐢𝐨𝐧",
            Topic = "General discussion.",
            Channels = Channels.Discussion
        };

        public override void PopulateMessages(MessageContainer messageContainer)
        {
        }
    }
}
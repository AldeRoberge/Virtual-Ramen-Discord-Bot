﻿using VirtualRamenDiscordBot.Channels.Base;
using VirtualRamenDiscordBot.Channels.Base.Messages.Base;

namespace VirtualRamenDiscordBot.Channels.Discussion
{
    public class FR_DiscussionChannel : ChannelGenerator
    {
        public override bool DeleteAllMessages => false;
        
        public override Channel Channel => new()
        {
            Id = ChannelConstants.DiscussionFR,
            Name = "『🌍』𝐃𝐢𝐬𝐜𝐮𝐬𝐬𝐢𝐨𝐧",
            Topic = "Discussion générale",
            ChannelsEnum = ChannelsEnum.Discussion
        };  

        public override void PopulateMessages(MessageContainer messageContainer)
        {
        }
    }
}
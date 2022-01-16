using Discord;

namespace _04_interactions_framework.Channels
{
    public abstract class SelectableRole
    {

        public abstract string Name { get; }
        
        public abstract IEmote Emote { get;  }
        public abstract EmbedBuilder EmbedBuilder { get; }

    }
}
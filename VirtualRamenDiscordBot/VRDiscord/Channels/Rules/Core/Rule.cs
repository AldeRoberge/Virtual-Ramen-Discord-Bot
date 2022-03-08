namespace VRDiscord.Channels.Rules.Core
{
    public class Rule
    {
        public string Description { get; set; }

        public Rule(string description)
        {
            Description = description;
        }
    }
}
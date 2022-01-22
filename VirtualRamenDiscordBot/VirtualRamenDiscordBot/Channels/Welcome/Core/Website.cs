namespace VirtualRamenDiscordBot.Channels.Welcome
{
    public class Website
    {
        public string URL;
        public string Name;
        public string ThumbnailURL;
        public string Description;

        public Website(string url, string name, string thumbnailUrl, string description)
        {
            URL = url;
            Name = name;
            ThumbnailURL = thumbnailUrl;
            Description = description;
        }
    }
}
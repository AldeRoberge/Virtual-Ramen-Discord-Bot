namespace VRDiscord.Channels.Welcome.Core
{
    public class Website
    {
        public string URL;
        public string Name;
        public string ThumbnailURL;
        public string Description;

        public Website(string url, string name, string imageName, string description)
        {
            URL = url;
            Name = name;
            ThumbnailURL = "http://virtualramen.ca/images/discord/" + imageName + ".png";
            Description = description;
        }
    }
}
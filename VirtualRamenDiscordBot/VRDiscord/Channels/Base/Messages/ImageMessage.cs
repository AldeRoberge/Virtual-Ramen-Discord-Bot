using System;
using System.IO;
using VRDiscord.Channels.Base.Messages.Base;

namespace VRDiscord.Channels.Base.Messages
{
    /// <summary>
    /// An image that is loaded from file.
    /// Uses the path relative to the assembly.
    /// </summary>
    public class ImageMessage : Message
    {
        public string ImagePath;

        public ImageMessage(string imagePath)
        {
            var fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, imagePath);
            ImagePath = fullPath;

            CheckImagePathValidity();
        }

        private void CheckImagePathValidity()
        {
            if (!File.Exists(ImagePath))
            {
                Console.WriteLine("Image file at '" + ImagePath + "' not found");
            }
        }
    }
}
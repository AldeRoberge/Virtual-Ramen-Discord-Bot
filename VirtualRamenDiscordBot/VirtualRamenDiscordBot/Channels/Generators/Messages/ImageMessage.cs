using System;
using System.IO;
using System.Reflection;

namespace _04_interactions_framework.Channels.Messages
{
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
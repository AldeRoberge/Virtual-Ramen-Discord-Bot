using System.Collections.Generic;
using Discord;

namespace VirtualRamenDiscordBot.Utils
{
    /// <summary>
    /// Utility class for generating gradient of colors.
    /// </summary>
    public static class GradientGenerator
    {
        // Creates a list of Color from two colors and a given range
        public static List<Color> GetColors(Color color1, Color color2, int range)
        {
            var colors = new List<Color>();
            for (var i = 0; i < range; i++)
            {
                var color = LerpColor(color1, color2, i / (float) range);
                colors.Add(color);
            }

            return colors;
        }


        // Creates a rainbow gradient in the given steps
        public static List<Color> GetRainbowGradient(int steps)
        {
            var colors = new List<Color>();
            for (var i = 0; i < steps; i++)
            {
                var color = ColorUtility.HSVToRGB(i / (float) steps, 1, 1);
                colors.Add(color);
            }

            return colors;
        }


        // Lerps between two color values
        private static Color LerpColor(Color color1, Color color2, float amount)
        {
            var r = (int) Lerp(color1.R, color2.R, amount);
            var g = (int) Lerp(color1.G, color2.G, amount);
            var b = (int) Lerp(color1.B, color2.B, amount);

            return new Color(r, g, b);
        }

        // Lerps between two values and the amount
        private static float Lerp(float value1, float value2, float amount)
        {
            return value1 + (value2 - value1) * amount;
        }
    }

    public class ColorUtility
    {
        // HSVToRGB
        public static Color HSVToRGB(float h, float s, float v)
        {
            var r = 0f;
            var g = 0f;
            var b = 0f;

            if (s == 0)
            {
                r = v;
                g = v;
                b = v;
            }
            else
            {
                var hTemp = h;
                while (hTemp >= 1)
                    hTemp -= 1;

                while (hTemp < 0)
                    hTemp += 1;

                if (hTemp < 1f / 6f)
                {
                    r = v;
                    g = v * (1f - s * (1f - hTemp * 6f));
                    b = v * (1f - s);
                }
                else if (hTemp < 2f / 6f)
                {
                    r = v * (1f - s * (hTemp * 6f - 1f));
                    g = v;
                    b = v * (1f - s);
                }
                else if (hTemp < 3f / 6f)
                {
                    r = v * (1f - s);
                    g = v;
                    b = v * (1f - s * (1f - (hTemp * 6f - 2f)));
                }
                else if (hTemp < 4f / 6f)
                {
                    r = v * (1f - s);
                    g = v * (1f - s * (hTemp * 6f - 3f));
                    b = v;
                }
                else if (hTemp < 5f / 6f)
                {
                    r = v * (1f - s * (1f - (hTemp * 6f - 4f)));
                    g = v * (1f - s);
                    b = v;
                }
                else
                {
                    r = v;
                    g = v * (1f - s);
                    b = v * (1f - s * (hTemp * 6f - 5f));
                }
            }

            return new Color(r, g, b);
        }
    }
}
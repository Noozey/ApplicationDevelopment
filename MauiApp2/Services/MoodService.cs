using MauiApp2.Models;

namespace MauiApp2.Services
{
    public class MoodService
    {
        public static MoodColor GetMoodColors(string category)
        {
            return category switch
            {
                "POSITIVE" => new MoodColor
                {
                    Background = "hsl(142 77% 92%)",
                    Border = "hsl(142 71% 45%)",
                    Text = "hsl(142 76% 28%)",
                    LightBorder = "hsl(142 71% 85%)",
                    Shadow = "rgba(34, 197, 94, 0.15)"
                },
                "NEUTRAL" => new MoodColor
                {
                    Background = "hsl(210 100% 94%)",
                    Border = "hsl(211 96% 62%)",
                    Text = "hsl(211 96% 36%)",
                    LightBorder = "hsl(211 96% 85%)",
                    Shadow = "rgba(59, 130, 246, 0.15)"
                },
                "NEGATIVE" => new MoodColor
                {
                    Background = "hsl(0 86% 94%)",
                    Border = "hsl(0 72% 51%)",
                    Text = "hsl(0 74% 42%)",
                    LightBorder = "hsl(0 72% 85%)",
                    Shadow = "rgba(239, 68, 68, 0.15)"
                },
                _ => new MoodColor
                {
                    Background = "hsl(0 0% 96%)",
                    Border = "hsl(220 9% 46%)",
                    Text = "hsl(222 47% 11%)",
                    LightBorder = "hsl(220 13% 91%)",
                    Shadow = "rgba(0, 0, 0, 0.05)"
                }
            };
        }
    }
}

namespace MauiApp2.Models
{
    public static class MoodOptions
    {
        public static List<MoodCategory> Categories => new()
        {
            new MoodCategory("POSITIVE", new() { "Happy", "Excited", "Relaxed", "Grateful" }),
            new MoodCategory("NEUTRAL", new() { "Calm", "Thoughtful", "Bored" }),
            new MoodCategory("NEGATIVE", new() { "Sad", "Angry", "Stressed", "Anxious" })
        };

        public static List<string> SecondaryMoods => new()
        {
            "Productive", "Tired", "Energetic", "Restless", "Relaxed", "Hungry",
            "Sick", "Inspired", "Motivated", "Happy", "Calm", "Anxious", "Stressed",
            "Overwhelmed", "Frustrated", "Lonely", "Content", "Focused", "Distracted",
            "Creative", "Reflective", "Thoughtful", "Confused", "Social", "Quiet",
            "Introverted", "Talkative", "Connected", "Isolated", "Grateful",
            "Hopeful", "Proud", "Self-Critical", "Mindful"
        };
    }
}
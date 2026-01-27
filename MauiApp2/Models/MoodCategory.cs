namespace MauiApp2.Models
{
    public class MoodCategory
    {
        public string Name { get; set; }
        public List<string> Moods { get; set; }

        public MoodCategory(string name, List<string> moods)
        {
            Name = name;
            Moods = moods;
        }
    }
}

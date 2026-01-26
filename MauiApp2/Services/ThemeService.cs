namespace MauiApp2.Services
{
    public class ThemeService
    {
        public string CurrentTheme { get; private set; } = "light";
        public event Action OnChange;

        public void ToggleTheme()
        {
            CurrentTheme = CurrentTheme == "light" ? "dark" : "light";
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
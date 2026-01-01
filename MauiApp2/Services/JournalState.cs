namespace MauiApp2.Services;
public class JournalState
{
    public bool ShowEditor { get; private set; }


    public void ToggleEditor()
    {
        ShowEditor = !ShowEditor;
    }
}

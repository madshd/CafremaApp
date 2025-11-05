namespace CafremaApp.Core.ValueObjects;

public class CommentInfo
{
    private string Text { get; set; }
    private DateTime LastEdited { get; set; }

    public CommentInfo(string text, DateTime lastEdited)
    {
        Text = text;
        LastEdited = lastEdited;
    }
}
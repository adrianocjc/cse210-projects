public class Word
{
    private string text;
    private bool isHidden;

    public Word(string text)
    {
        this.text = text;
        this.isHidden = false;
    }

    public void Hide()
    {
        isHidden = true;
    }

    public bool IsHidden()
    {
        return isHidden;
    }

    public string GetDisplayText()
    {
        return isHidden ? new string('_', text.Length) : text;
    }
}

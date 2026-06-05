

public class Word
{
    private string _text;
    private string _displayText;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _displayText = text;
        _isHidden = false;
    }

    public string GetText()
    {
        return _text;
    }

    public void Hide(string hiddenText)
    {
        _displayText = hiddenText;
        _isHidden = true;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    public string GetDisplayText()
    {
        return _displayText;
    }
}
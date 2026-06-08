using System;

public class Scripture
{
    private Reference _reference;
    private string _text;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _text = text;
    }

    public string GetText()
    {
        return _text;
    }

    public string GetReferenceText()
    {
        return _reference.GetDisplayText();
    }

    public string GetDisplayText()
    {
        return $"{_reference.GetDisplayText()} {_text}";
    }
}
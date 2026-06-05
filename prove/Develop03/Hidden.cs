using System;
using System.Collections.Generic;

public class Hidden
{
    private List<string> _hiddenWords = new List<string>();
    private List<string> _randomWords = new List<string>();
    private List<int> _randomWordsAddress = new List<int>();
    private List<Word> _verse = new List<Word>();

    private Scripture _scripture;
    private Random _random = new Random();

    public Hidden(Scripture scripture)
    {
        _scripture = scripture;
        VerseList(scripture.GetText());
    }

    private void VerseList(string scriptureText)
    {
        string[] words = scriptureText.Split(" ");

        for (int i = 0; i < words.Length; i++)
        {
            Word word = new Word(words[i]);
            _verse.Add(word);
        }
    }

    public void Hide()
    {
        PickRandomWords();
        HideWords();
        ReplaceWords();
    }

    private void PickRandomWords()
    {
        _randomWords.Clear();
        _randomWordsAddress.Clear();

        List<int> visibleWords = new List<int>();

        for (int i = 0; i < _verse.Count; i++)
        {
            if (!_verse[i].IsHidden())
            {
                visibleWords.Add(i);
            }
        }

        int wordsToHide = 3;

        if (visibleWords.Count < 3)
        {
            wordsToHide = visibleWords.Count;
        }

        for (int i = 0; i < wordsToHide; i++)
        {
            int randomIndex = _random.Next(visibleWords.Count);
            int wordAddress = visibleWords[randomIndex];

            _randomWords.Add(_verse[wordAddress].GetText());
            _randomWordsAddress.Add(wordAddress);

            visibleWords.RemoveAt(randomIndex);
        }
    }

    private void HideWords()
    {
        _hiddenWords.Clear();

        for (int i = 0; i < _randomWords.Count; i++)
        {
            string hiddenWord = new string('_', _randomWords[i].Length);
            _hiddenWords.Add(hiddenWord);
        }
    }

    private void ReplaceWords()
    {
        for (int i = 0; i < _randomWordsAddress.Count; i++)
        {
            int address = _randomWordsAddress[i];
            _verse[address].Hide(_hiddenWords[i]);
        }
    }

    public string GetVerse()
    {
        List<string> displayWords = new List<string>();

        for (int i = 0; i < _verse.Count; i++)
        {
            displayWords.Add(_verse[i].GetDisplayText());
        }

        string verseText = string.Join(" ", displayWords);

        return $"{_scripture.GetReferenceText()} {verseText}";
    }

    public bool IsCompletelyHidden()
    {
        for (int i = 0; i < _verse.Count; i++)
        {
            if (!_verse[i].IsHidden())
            {
                return false;
            }
        }

        return true;
    }
}
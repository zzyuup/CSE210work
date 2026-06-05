using System;

class Program
{
    static void Main(string[] args)
    {
        GetScriptures scriptures = new GetScriptures();
        Scripture scripture = scriptures.GetRandomScripture();

        Hidden hidden = new Hidden(scripture);

        bool running = true;

        while (running && !hidden.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(hidden.GetVerse());
            Console.WriteLine();

            Console.Write("Press enter to continue or type 'quit' to finish: ");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                running = false;
            }
            else
            {
                hidden.Hide();
            }
        }

        if (hidden.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(hidden.GetVerse());
        }
    }
}

// public class GetScriptures
// {
//     private List<Scripture> _scriptures = new List<Scripture>();
//     private Random _random = new Random();

//     public GetScriptures()
//     {
//         _scriptures.Add(new Scripture(
//             new Reference("1 Nephi", 3, 7),
//             "I will go and do the things which the Lord hath commanded"
//         ));

//         _scriptures.Add(new Scripture(
//             new Reference("2 Nephi", 2, 25),
//             "Adam fell that men might be and men are that they might have joy"
//         ));

//         _scriptures.Add(new Scripture(
//             new Reference("2 Nephi", 31, 20),
//             "Wherefore ye must press forward with a steadfastness in Christ having a perfect brightness of hope"
//         ));

//         _scriptures.Add(new Scripture(
//             new Reference("Mosiah", 2, 17),
//             "When ye are in the service of your fellow beings ye are only in the service of your God"
//         ));

//         _scriptures.Add(new Scripture(
//             new Reference("Alma", 32, 21),
//             "Faith is not to have a perfect knowledge of things therefore if ye have faith ye hope for things which are not seen"
//         ));

//         _scriptures.Add(new Scripture(
//             new Reference("Ether", 12, 27),
//             "If men come unto me I will show unto them their weakness and my grace is sufficient for the meek"
//         ));

//         _scriptures.Add(new Scripture(
//             new Reference("Moroni", 10, 4, 5),
//             "Ask God the Eternal Father in the name of Christ if these things are not true and by the power of the Holy Ghost ye may know the truth"
//         ));
//     }

//     public Scripture GetRandomScripture()
//     {
//         int index = _random.Next(_scriptures.Count);
//         return _scriptures[index];
//     }
// }

// public class Scripture
// {
//     private Reference _reference;
//     private string _text;

//     public Scripture(Reference reference, string text)
//     {
//         _reference = reference;
//         _text = text;
//     }

//     public string GetText()
//     {
//         return _text;
//     }

//     public string GetReferenceText()
//     {
//         return _reference.GetDisplayText();
//     }

//     public string GetDisplayText()
//     {
//         return $"{_reference.GetDisplayText()} {_text}";
//     }
// }

// public class Reference
// {
//     private string _book;
//     private int _chapter;
//     private int _startVerse;
//     private int _endVerse;

//     public Reference(string book, int chapter, int verse)
//     {
//         _book = book;
//         _chapter = chapter;
//         _startVerse = verse;
//         _endVerse = verse;
//     }

//     public Reference(string book, int chapter, int startVerse, int endVerse)
//     {
//         _book = book;
//         _chapter = chapter;
//         _startVerse = startVerse;
//         _endVerse = endVerse;
//     }

//     public string GetDisplayText()
//     {
//         if (_startVerse == _endVerse)
//         {
//             return $"{_book} {_chapter}:{_startVerse}";
//         }
//         else
//         {
//             return $"{_book} {_chapter}:{_startVerse}-{_endVerse}";
//         }
//     }
// }

// public class Hidden
// {
//     private List<string> _hiddenWords = new List<string>();
//     private List<string> _randomWords = new List<string>();
//     private List<int> _randomWordsAddress = new List<int>();
//     private List<Word> _verse = new List<Word>();

//     private Scripture _scripture;
//     private Random _random = new Random();

//     public Hidden(Scripture scripture)
//     {
//         _scripture = scripture;
//         VerseList(scripture.GetText());
//     }

//     private void VerseList(string scriptureText)
//     {
//         string[] words = scriptureText.Split(" ");

//         for (int i = 0; i < words.Length; i++)
//         {
//             Word word = new Word(words[i]);
//             _verse.Add(word);
//         }
//     }

//     public void Hide()
//     {
//         PickRandomWords();
//         HideWords();
//         ReplaceWords();
//     }

//     private void PickRandomWords()
//     {
//         _randomWords.Clear();
//         _randomWordsAddress.Clear();

//         List<int> visibleWords = new List<int>();

//         for (int i = 0; i < _verse.Count; i++)
//         {
//             if (!_verse[i].IsHidden())
//             {
//                 visibleWords.Add(i);
//             }
//         }

//         int wordsToHide = 3;

//         if (visibleWords.Count < 3)
//         {
//             wordsToHide = visibleWords.Count;
//         }

//         for (int i = 0; i < wordsToHide; i++)
//         {
//             int randomIndex = _random.Next(visibleWords.Count);
//             int wordAddress = visibleWords[randomIndex];

//             _randomWords.Add(_verse[wordAddress].GetText());
//             _randomWordsAddress.Add(wordAddress);

//             visibleWords.RemoveAt(randomIndex);
//         }
//     }

//     private void HideWords()
//     {
//         _hiddenWords.Clear();

//         for (int i = 0; i < _randomWords.Count; i++)
//         {
//             string hiddenWord = new string('_', _randomWords[i].Length);
//             _hiddenWords.Add(hiddenWord);
//         }
//     }

//     private void ReplaceWords()
//     {
//         for (int i = 0; i < _randomWordsAddress.Count; i++)
//         {
//             int address = _randomWordsAddress[i];
//             _verse[address].Hide(_hiddenWords[i]);
//         }
//     }

//     public string GetVerse()
//     {
//         List<string> displayWords = new List<string>();

//         for (int i = 0; i < _verse.Count; i++)
//         {
//             displayWords.Add(_verse[i].GetDisplayText());
//         }

//         string verseText = string.Join(" ", displayWords);

//         return $"{_scripture.GetReferenceText()} {verseText}";
//     }

//     public bool IsCompletelyHidden()
//     {
//         for (int i = 0; i < _verse.Count; i++)
//         {
//             if (!_verse[i].IsHidden())
//             {
//                 return false;
//             }
//         }

//         return true;
//     }
// }

// public class Word
// {
//     private string _text;
//     private string _displayText;
//     private bool _isHidden;

//     public Word(string text)
//     {
//         _text = text;
//         _displayText = text;
//         _isHidden = false;
//     }

//     public string GetText()
//     {
//         return _text;
//     }

//     public void Hide(string hiddenText)
//     {
//         _displayText = hiddenText;
//         _isHidden = true;
//     }

//     public bool IsHidden()
//     {
//         return _isHidden;
//     }

//     public string GetDisplayText()
//     {
//         return _displayText;
//     }
// }
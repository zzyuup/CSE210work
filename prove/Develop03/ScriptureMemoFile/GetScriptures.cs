using System;
using System.Collections.Generic;
using System.IO;

public class GetScriptures
{
    private List<Scripture> _scriptures = new List<Scripture>();
    private Random _random = new Random();

    public GetScriptures()
    {
        string[] lines = File.ReadAllLines("ScripturesLib.txt");

        for (int i = 0; i < lines.Length; i++)
        {
            string line = lines[i];

            if (line.Trim() != "")
            {
                List<string> parts = ParseCsvLine(line);

                string book = parts[0];
                int chapter = int.Parse(parts[1]);
                int verse = int.Parse(parts[2]);
                string scriptureText = parts[3];

                Reference reference = new Reference(book, chapter, verse);
                Scripture scripture = new Scripture(reference, scriptureText);

                _scriptures.Add(scripture);
            }
        }
    }
    public Scripture GetRandomScripture()
    {
        int index = _random.Next(_scriptures.Count);
        return _scriptures[index];
    }

    private List<string> ParseCsvLine(string line)
    {
        List<string> parts = new List<string>();
        string currentPart = "";
        bool insideQuotes = false;

        for (int i = 0; i < line.Length; i++)
        {
            char c = line[i];

            if (c == '"')
            {
                insideQuotes = !insideQuotes;
            }
            else if (c == ',' && !insideQuotes)
            {
                parts.Add(currentPart.Trim());
                currentPart = "";
            }
            else
            {
                currentPart += c;
            }
        }
        
        parts.Add(currentPart.Trim());
        return parts;
    }
}
using System;
using System.Collections.Generic;
using System.IO;

// Public Class: Journal 
// Attributes:
//   - _entries : List<string>
//   - _prompts : List<string>
// Behaviors:
//   + Prompt() : void
//   + Write() : void
//   + Display() : void
//   + Save() : void
//   + Load() : void
public class Journal
{
    public List<string> _entries = new List<string>();

    public List<string> _prompts = new List<string>();
    public void Prompt()
    {
        string[] lines = File.ReadAllLines("JournalPrompt.txt");

        for (int i = 0; i < lines.Length; i++)
        {
            string prompt = lines[i].Trim();
            prompt = prompt.Trim(',');
            prompt = prompt.Trim('"');
            if (prompt != "")
            {
                _prompts.Add(prompt);
            }
        }
    }

//  Write() creates the entry.
    public void Write()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        string prompt = _prompts[index];

        Console.WriteLine(prompt);
        Console.Write("> ");
        string response = Console.ReadLine();

        string date = DateTime.Now.ToShortDateString();
        string entry = $"{date}|{prompt}|{response}";

        _entries.Add(entry);
    }
//   Display() shows all saved entries.
    public void Display()
    {
        for (int i = 0; i < _entries.Count; i++)
        {
            string[] parts = _entries[i].Split("|");
            Console.WriteLine($"Date: {parts[0]}");
            Console.WriteLine($"Prompt: {parts[1]}");
            Console.WriteLine($"Response: {parts[2]}");
            Console.WriteLine();
        }
    }
//   Save() writes the list to a file.
    public void Save()
    {
        Console.Write("What is the filename? ");
        string filename = Console.ReadLine();
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            for (int i = 0; i < _entries.Count; i++)
            {
                outputFile.WriteLine(_entries[i]);
            }
        }

        Console.WriteLine("Journal saved.");
    }
//   Load() reads the list back from a file.
    public void Load()
    {
        Console.Write("What is the filename? ");
        string filename = Console.ReadLine();
        _entries.Clear();
        string[] lines = File.ReadAllLines(filename);
        for (int i = 0; i < lines.Length; i++)
        {
            _entries.Add(lines[i]);
        }
        Console.WriteLine("Journal loaded.");
    }
}


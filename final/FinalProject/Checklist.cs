using System;
using System.Collections.Generic;
using System.IO;

public class Checklist
{
    private List<RequiredExpense> _requiredExpenses = new List<RequiredExpense>();

    public void AddRequiredExpense(RequiredExpense expense)
    {
        _requiredExpenses.Add(expense);
    }

    public void DisplayChecklist()
    {
        Console.WriteLine();
        Console.WriteLine("Required Checklist:");

        if (_requiredExpenses.Count == 0)
        {
            Console.WriteLine("No required expenses added yet.");
            Console.WriteLine("Format: name,cost");
            return;
        }

        for (int i = 0; i < _requiredExpenses.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_requiredExpenses[i].GetName()}: ${_requiredExpenses[i].GetCost()}");
        }

        Console.WriteLine();
        Console.WriteLine($"Total required expenses: ${GetTotalRequiredCost()}");
    }

    public double GetTotalRequiredCost()
    {
        double total = 0;

        for (int i = 0; i < _requiredExpenses.Count; i++)
        {
            total += _requiredExpenses[i].GetCost();
        }

        return total;
    }

    public void SaveChecklist(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            for (int i = 0; i < _requiredExpenses.Count; i++)
            {
                outputFile.WriteLine($"{_requiredExpenses[i].GetName()},{_requiredExpenses[i].GetCost()}");
            }
        }

        Console.WriteLine("Checklist saved.");
        Console.WriteLine("Saved format: name,cost");
    }

    public void ImportChecklist(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        _requiredExpenses.Clear();

        string[] lines = File.ReadAllLines(filename);

        for (int i = 0; i < lines.Length; i++)
        {
            string line = lines[i];

            if (line.Trim() != "")
            {
                string[] parts = line.Split(",");

                if (parts.Length >= 2)
                {
                    string name = parts[0];
                    double cost = double.Parse(parts[1]);

                    RequiredExpense expense = new RequiredExpense(name, cost);
                    _requiredExpenses.Add(expense);
                }
            }
        }

        Console.WriteLine("Checklist imported.");
    }

    public List<RequiredExpense> GetRequiredExpenses()
    {
        return _requiredExpenses;
    }
}



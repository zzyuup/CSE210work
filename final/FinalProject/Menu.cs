using System;

public class Menu
{
    private string _choice;

    public void DisplayMenu()
    {
        Console.WriteLine();
        Console.WriteLine("Salary Tracker Menu");
        Console.WriteLine("1. Set salary and time period");
        Console.WriteLine("2. Add required checklist item");
        Console.WriteLine("3. Display required checklist");
        Console.WriteLine("4. Show required plan summary");
        Console.WriteLine("5. Save required checklist");
        Console.WriteLine("6. Import required checklist");
        Console.WriteLine("7. Add sandbox purchase");
        Console.WriteLine("8. Add event expense");
        Console.WriteLine("9. Set sales tax");
        Console.WriteLine("10. Display sandbox purchases");
        Console.WriteLine("11. Show full plan summary");
        Console.WriteLine("12. Save current plan");
        Console.WriteLine("13. Restart sandbox");
        Console.WriteLine("14. Quit");
    }

    public string GetChoice()
    {
        Console.Write("Select a choice: ");
        _choice = Console.ReadLine();
        return _choice;
    }
}




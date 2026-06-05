using System;

// Interaction:
//   Program controls the menu.
//   Journal stores each journal entry as one string in this format: date|prompt|response


// Public Class: Program
// Attributes:
//   none
// Behaviors:
//   + Main(args : string[]) : void
//   + DisplayMenu() : void
//   + Quit() : void
class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        journal.Prompt();
        bool running = true;
        Console.WriteLine("Welcome to the Journal Program!");

        while (running)
        {
            DisplayMenu();
            Console.Write("What would you like to do? ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                journal.Write();
            }
            else if (choice == "2")
            {
                journal.Display();
            }
            else if (choice == "3")
            {
                journal.Load();
            }
            else if (choice == "4")
            {
                journal.Save();
            }
            else if (choice == "5")
            {
                Quit();
                running = false;
            }
            else
            {
                Console.WriteLine("Please choose a number from 1 to 5.");
            }
        }
    }

    static void DisplayMenu()
    {
        Console.WriteLine();
        Console.WriteLine("Please select one of the following choices:");
        Console.WriteLine("1. Write");
        Console.WriteLine("2. Display");
        Console.WriteLine("3. Load");
        Console.WriteLine("4. Save");
        Console.WriteLine("5. Quit");
    }

    static void Quit()
    {
        Console.WriteLine("Goodbye!");
    }
}





using System;

class Program
{
    static void Main(string[] args)
    {
        bool running = true;

        BreathingActivity breathing = new BreathingActivity();
        ReflectionActivity reflection = new ReflectionActivity();
        ListingActivity listing = new ListingActivity();

        while (running)
        {
            DisplayMenu();

            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                breathing.Run();
            }
            else if (choice == "2")
            {
                reflection.Run();
            }
            else if (choice == "3")
            {
                listing.Run();
            }
            else if (choice == "4")
            {
                Quit();
                running = false;
            }
            else
            {
                Console.WriteLine("Please choose a number from 1 to 4.");
                Console.WriteLine("Press enter to continue.");
                Console.ReadLine();
            }
        }
    }

    static void DisplayMenu()
    {
        Console.Clear();
        Console.WriteLine("Menu Options:");
        Console.WriteLine("  1. Start breathing activity");
        Console.WriteLine("  2. Start reflecting activity");
        Console.WriteLine("  3. Start listing activity");
        Console.WriteLine("  4. Quit");
    }

    static void Quit()
    {
        Console.WriteLine("Goodbye!");
    }
}



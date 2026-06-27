using System;

class Program
{
    static void Main(string[] args)
    {
        Menu menu = new Menu();
        Goals goals = new Goals();

        bool running = true;

        while (running)
        {
            Console.WriteLine();
            Console.WriteLine($"You have {goals.GetTotalScore()} points.");
            Console.WriteLine();

            menu.DisplayMenu();
            string choice = menu.GetChoice();

            if (choice == "1")
            {
                CreateGoal(goals);
            }
            else if (choice == "2")
            {
                goals.DisplayGoals();
            }
            else if (choice == "3")
            {
                goals.SaveGoals();
            }
            else if (choice == "4")
            {
                goals.LoadGoals();
            }
            else if (choice == "5")
            {
                goals.RecordEvent();
            }
            else if (choice == "6")
            {
                Console.WriteLine("Goodbye!");
                running = false;
            }
            else
            {
                Console.WriteLine("Please choose a number from 1 to 6.");
            }
        }
    }

    static void CreateGoal(Goals goals)
    {
        Console.WriteLine("The types of goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");

        string type = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        if (type == "1")
        {
            SimpleGoal goal = new SimpleGoal(name, description, points);
            goals.AddGoal(goal);
        }
        else if (type == "2")
        {
            EternalGoal goal = new EternalGoal(name, description, points);
            goals.AddGoal(goal);
        }
        else if (type == "3")
        {
            Console.Write("How many times does this goal need to be completed for a bonus? ");
            int target = int.Parse(Console.ReadLine());

            Console.Write("What is the bonus for completing it that many times? ");
            int bonus = int.Parse(Console.ReadLine());

            CheckListGoal goal = new CheckListGoal(name, description, points, target, bonus);
            goals.AddGoal(goal);
        }
    }
}






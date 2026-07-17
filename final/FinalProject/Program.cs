using System;

class Program
{
    static void Main(string[] args)
    {
        Menu menu = new Menu();
        BudgetPlan plan = new BudgetPlan();

        bool running = true;

        while (running)
        {
            Console.WriteLine();
            menu.DisplayMenu();
            string choice = menu.GetChoice();

            if (choice == "1")
            {
                Console.Write("Enter salary amount: ");
                double amount = double.Parse(Console.ReadLine());

                Console.Write("Enter time period, paycheck week, month, or year: ");
                string timePeriod = Console.ReadLine();

                plan.SetSalary(amount, timePeriod);
                Console.WriteLine("Salary saved.");
            }
            else if (choice == "2")
            {
                Console.WriteLine("Required checklist format: name,cost");
                Console.Write("Enter required item name: ");
                string name = Console.ReadLine();

                Console.Write("Enter cost: ");
                double cost = double.Parse(Console.ReadLine());

                plan.AddRequiredExpense(name, cost);
                Console.WriteLine("Required expense added.");
            }
            else if (choice == "3")
            {
                plan.DisplayChecklist();
            }
            else if (choice == "4")
            {
                plan.ShowPlanSummary();
            }
            else if (choice == "5")
            {
                Console.WriteLine("Checklist save format:");
                Console.WriteLine("name,cost");
                Console.WriteLine("Example:");
                Console.WriteLine("Rent,900");
                Console.WriteLine("Food,350");

                Console.Write("Enter filename to save checklist: ");
                string filename = Console.ReadLine();

                plan.SaveChecklist(filename);
            }
            else if (choice == "6")
            {
                Console.WriteLine("Checklist import format:");
                Console.WriteLine("name,cost");
                Console.WriteLine("Example:");
                Console.WriteLine("Rent,900");
                Console.WriteLine("Food,350");

                Console.Write("Enter filename to import checklist: ");
                string filename = Console.ReadLine();

                plan.ImportChecklist(filename);
            }
            else if (choice == "7")
            {
                Console.Write("Enter sandbox item name: ");
                string name = Console.ReadLine();

                Console.Write("Enter price: ");
                double cost = double.Parse(Console.ReadLine());

                plan.AddOptionalPurchase(name, cost);
                Console.WriteLine("Sandbox purchase added.");
            }
            else if (choice == "8")
            {
                Console.Write("Enter event name: ");
                string name = Console.ReadLine();

                Console.Write("Enter price: ");
                double cost = double.Parse(Console.ReadLine());

                Console.Write("Enter event date: ");
                string date = Console.ReadLine();

                plan.AddEventExpense(name, cost, date);
                Console.WriteLine("Event expense added.");
            }
            else if (choice == "9")
            {
                Console.Write("Enter sales tax percent: ");
                double tax = double.Parse(Console.ReadLine());

                plan.SetSalesTax(tax);
                Console.WriteLine("Sales tax saved.");
            }
            else if (choice == "10")
            {
                plan.DisplaySandboxItems();
            }
            else if (choice == "11")
            {
                plan.ShowPlanSummary();
            }
            else if (choice == "12")
            {
                Console.Write("Enter filename to save plan: ");
                string filename = Console.ReadLine();

                plan.SavePlan(filename);
            }
            else if (choice == "13")
            {
                plan.RestartSandbox();
            }
            else if (choice == "14")
            {
                Console.WriteLine("Goodbye!");
                running = false;
            }
            else
            {
                Console.WriteLine("Please choose a number from 1 to 14.");
            }
        }
    }
}




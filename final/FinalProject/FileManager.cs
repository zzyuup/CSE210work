using System;
using System.IO;
using System.Collections.Generic;

public class FileManager
{
    public void SavePlan(string filename, BudgetPlan plan)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine("Salary:");
            outputFile.WriteLine(plan.GetSalaryText());
            outputFile.WriteLine();

            outputFile.WriteLine("Required Checklist:");
            List<RequiredExpense> requiredExpenses = plan.GetRequiredExpenses();

            for (int i = 0; i < requiredExpenses.Count; i++)
            {
                outputFile.WriteLine($"{requiredExpenses[i].GetName()},{requiredExpenses[i].GetCost()}");
            }

            outputFile.WriteLine();

            outputFile.WriteLine("Virtual Purchases:");
            List<BaseExpense> sandboxExpenses = plan.GetSandboxExpenses();

            for (int i = 0; i < sandboxExpenses.Count; i++)
            {
                outputFile.WriteLine($"{sandboxExpenses[i].GetName()},{sandboxExpenses[i].GetCost()}");
            }

            outputFile.WriteLine();

            outputFile.WriteLine("Result:");
            outputFile.WriteLine(plan.GetResult());
        }

        Console.WriteLine("Plan saved.");
    }
}






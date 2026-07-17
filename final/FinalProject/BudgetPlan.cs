using System;
using System.Collections.Generic;

public class BudgetPlan
{
    private Salary _salary;
    private Checklist _checklist;
    private Sandbox _sandbox;
    private FileManager _fileManager;

    public BudgetPlan()
    {
        _salary = new Salary(0, "month");
        _checklist = new Checklist();
        _sandbox = new Sandbox();
        _fileManager = new FileManager();
    }

    public void SetSalary(double amount, string timePeriod)
    {
        _salary = new Salary(amount, timePeriod);
    }

    public void AddRequiredExpense(string name, double cost)
    {
        RequiredExpense expense = new RequiredExpense(name, cost);
        _checklist.AddRequiredExpense(expense);
    }

    public void AddOptionalPurchase(string name, double cost)
    {
        BaseExpense expense = new OptionalPurchase(name, cost);
        _sandbox.AddExpense(expense);
    }

    public void AddEventExpense(string name, double cost, string date)
    {
        BaseExpense eventExpense = new EventExpense(name, cost, date);
        _sandbox.AddExpense(eventExpense);
    }

    public void SetSalesTax(double percent)
    {
        _sandbox.SetSalesTax(percent);
    }

    public void DisplayChecklist()
    {
        _checklist.DisplayChecklist();
    }

    public void DisplaySandboxItems()
    {
        _sandbox.DisplaySandboxItems();
    }

    public void SaveChecklist(string filename)
    {
        _checklist.SaveChecklist(filename);
    }

    public void ImportChecklist(string filename)
    {
        _checklist.ImportChecklist(filename);
    }

    public double GetMoneyLeftAfterRequired()
    {
        return _salary.GetAmount() - _checklist.GetTotalRequiredCost();
    }

    public double GetMoneyLeftAfterSandbox()
    {
        return _salary.GetAmount() - _checklist.GetTotalRequiredCost() - _sandbox.GetTotalWithTax();
    }

    public bool CanAffordPurchase()
    {
        return GetMoneyLeftAfterSandbox() >= 0;
    }

    public string GetResult()
    {
        if (CanAffordPurchase())
        {
            return $"You can afford this plan within your {_salary.GetTimePeriod()} period. Money left: ${GetMoneyLeftAfterSandbox()}";
        }
        else
        {
            return $"You cannot afford this plan within your {_salary.GetTimePeriod()} period. You are short: ${GetMoneyLeftAfterSandbox() * -1}";
        }
    }

    public void ShowPlanSummary()
    {
        Console.WriteLine();
        Console.WriteLine("Plan Summary");
        Console.WriteLine($"Salary: ${_salary.GetAmount()} per {_salary.GetTimePeriod()}");
        Console.WriteLine();

        _checklist.DisplayChecklist();

        Console.WriteLine($"Money left after required expenses: ${GetMoneyLeftAfterRequired()}");
        Console.WriteLine();

        _sandbox.DisplaySandboxItems();

        Console.WriteLine();
        Console.WriteLine($"Money left after sandbox purchases: ${GetMoneyLeftAfterSandbox()}");
        Console.WriteLine($"Result: {GetResult()}");
    }

    public void SavePlan(string filename)
    {
        _fileManager.SavePlan(filename, this);
    }

    public void RestartSandbox()
    {
        _sandbox.ClearSandbox();
    }

    public string GetSalaryText()
    {
        return $"{_salary.GetAmount()} per {_salary.GetTimePeriod()}";
    }

    public List<RequiredExpense> GetRequiredExpenses()
    {
        return _checklist.GetRequiredExpenses();
    }

    public List<BaseExpense> GetSandboxExpenses()
    {
        return _sandbox.GetExpenses();
    }
}



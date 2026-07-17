using System;
using System.Collections.Generic;

public class Sandbox
{
    private List<BaseExpense> _expenses = new List<BaseExpense>();
    private double _salesTaxPercent;

    public Sandbox()
    {
        _salesTaxPercent = 0;
    }

    public void AddExpense(BaseExpense expense)
    {
        _expenses.Add(expense);
    }

    public void SetSalesTax(double percent)
    {
        _salesTaxPercent = percent;
    }

    public void DisplaySandboxItems()
    {
        Console.WriteLine();
        Console.WriteLine("Sandbox Purchases:");

        if (_expenses.Count == 0)
        {
            Console.WriteLine("No sandbox purchases added yet.");
            return;
        }

        for (int i = 0; i < _expenses.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_expenses[i].GetDisplayText()}");
        }

        Console.WriteLine();
        Console.WriteLine($"Sandbox subtotal: ${GetSubtotal()}");
        Console.WriteLine($"Sales tax percent: {_salesTaxPercent}%");
        Console.WriteLine($"Tax amount: ${GetTaxAmount()}");
        Console.WriteLine($"Sandbox total with tax: ${GetTotalWithTax()}");
    }

    public double GetSubtotal()
    {
        double total = 0;

        for (int i = 0; i < _expenses.Count; i++)
        {
            total += _expenses[i].CalculateCost();
        }

        return total;
    }

    public double GetTaxAmount()
    {
        return GetSubtotal() * (_salesTaxPercent / 100);
    }

    public double GetTotalWithTax()
    {
        return GetSubtotal() + GetTaxAmount();
    }

    public void ClearSandbox()
    {
        _expenses.Clear();
        Console.WriteLine("Sandbox restarted.");
    }

    public List<BaseExpense> GetExpenses()
    {
        return _expenses;
    }

    public double GetSalesTaxPercent()
    {
        return _salesTaxPercent;
    }
}




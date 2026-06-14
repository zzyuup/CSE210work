using System;
using System.Threading;

public abstract class Activity
{
    private string _name;
    private string _description;
    private int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
        _duration = 0;
    }

    public void Run()
    {
        DisplayStartingMessage();
        PerformActivity();
        DisplayEndingMessage();
    }

    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}.");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();

        Console.Write("How long, in seconds, would you like for your session? ");
        string input = Console.ReadLine();

        int seconds;
        if (!int.TryParse(input, out seconds) || seconds <= 0)
        {
            seconds = 10;
        }

        SetDuration(seconds);

        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(3);
        Console.WriteLine();
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!");
        ShowSpinner(3);
        Console.WriteLine();
        Console.WriteLine($"You have completed another {_duration} seconds of the {_name}.");
        ShowSpinner(3);
        Console.WriteLine();
        Console.WriteLine("Press enter to return to the menu.");
        Console.ReadLine();
    }

    public void SetDuration(int seconds)
    {
        _duration = seconds;
    }

    protected int GetDuration()
    {
        return _duration;
    }

    protected abstract void PerformActivity();

    protected void ShowSpinner(int seconds)
    {
        string[] frames = { "/", "|", "\\", "-" };
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        int i = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write(frames[i]);
            Thread.Sleep(250);
            Console.Write("\b \b");

            i++;
            if (i >= frames.Length)
            {
                i = 0;
            }
        }
    }

    protected void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    protected void Pause(int seconds)
    {
        Thread.Sleep(seconds * 1000);
    }
}




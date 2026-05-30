using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "Computer Hardware Builder";
        job1._company = "Personal PC Business";
        job1._startYear = 2021;
        job1._endYear = 2024;

        Job job2 = new Job();
        job2._jobTitle = "Computer Engineering Student";
        job2._company = "BYU-Idaho";
        job2._startYear = 2025;
        job2._endYear = 2026;
        
        Resume myResume = new Resume();
        myResume._name = "Yester";
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);
        myResume.Display();
    }
}

public class Job
{
    public string _company;
    public string _jobTitle;
    public int _startYear;
    public int _endYear;
    public void Display()
    {
        Console.WriteLine($"{_jobTitle} ({_company}) {_startYear}-{_endYear}");
    }
}

public class Resume
{
    public string _name;
    public List<Job> _jobs = new List<Job>();

    public void Display()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine("Jobs:");
        for (int i = 0; i < _jobs.Count; i++)
        {
            _jobs[i].Display();
        }
    }
}
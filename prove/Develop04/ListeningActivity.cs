using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>();
    private List<string> _items = new List<string>();

    private ListingPromptRandomizer _promptRandomizer;
    private ListingPromptTracker _promptTracker;

    public ListingActivity()
        : base(
            "Listing Activity",
            "This activity will help you reflect on the good things in your life by having you list as many things as you can."
        )
    {
        _prompts.Add("Who are people that you appreciate?");
        _prompts.Add("What are personal strengths of yours?");
        _prompts.Add("Who are people that you have helped this week?");
        _prompts.Add("When have you felt the Holy Ghost this month?");
        _prompts.Add("Who are some of your personal heroes?");

        _promptRandomizer = new ListingPromptRandomizer(_prompts.Count);
        _promptTracker = new ListingPromptTracker();
    }

    protected override void PerformActivity()
    {
        _items.Clear();

        DisplayRandomPrompt();

        Console.WriteLine();
        Console.WriteLine("You may begin in:");
        ShowCountdown(5);
        Console.WriteLine();

        CollectItems();
        DisplayItemCount();
    }

    private void DisplayRandomPrompt()
    {
        if (_promptRandomizer.IsRoundFinished() || _promptTracker.AllUsed(_prompts.Count))
        {
            ResetPromptRound();
        }

        int index = _promptRandomizer.GetNextIndex();
        _promptTracker.MarkUsed(index);

        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine($"--- {_prompts[index]} ---");
    }

    private void CollectItems()
    {
        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string item = Console.ReadLine();

            if (item == "")
            {
                break;
            }

            _items.Add(item);
        }
    }

    private void DisplayItemCount()
    {
        Console.WriteLine();
        Console.WriteLine($"You listed {_items.Count} items.");
    }

    private void ResetPromptRound()
    {
        _promptTracker.Reset();
        _promptRandomizer.ShuffleOrder();
    }

    private class ListingPromptRandomizer
    {
        private List<int> _promptIndexes = new List<int>();
        private Random _random = new Random();
        private int _currentIndex;
        private int _promptCount;

        public ListingPromptRandomizer(int promptCount)
        {
            _promptCount = promptCount;
            ShuffleOrder();
        }

        public void ShuffleOrder()
        {
            _promptIndexes.Clear();

            for (int i = 0; i < _promptCount; i++)
            {
                _promptIndexes.Add(i);
            }

            for (int i = 0; i < _promptIndexes.Count; i++)
            {
                int randomIndex = _random.Next(i, _promptIndexes.Count);
                int temp = _promptIndexes[i];
                _promptIndexes[i] = _promptIndexes[randomIndex];
                _promptIndexes[randomIndex] = temp;
            }

            _currentIndex = 0;
        }

        public int GetNextIndex()
        {
            if (IsRoundFinished())
            {
                ShuffleOrder();
            }

            int index = _promptIndexes[_currentIndex];
            _currentIndex++;
            return index;
        }

        public bool IsRoundFinished()
        {
            return _currentIndex >= _promptIndexes.Count;
        }
    }

    private class ListingPromptTracker
    {
        private HashSet<int> _usedIndexes = new HashSet<int>();

        public void MarkUsed(int index)
        {
            _usedIndexes.Add(index);
        }

        public bool IsUsed(int index)
        {
            return _usedIndexes.Contains(index);
        }

        public bool AllUsed(int total)
        {
            return _usedIndexes.Count >= total;
        }

        public void Reset()
        {
            _usedIndexes.Clear();
        }
    }
}




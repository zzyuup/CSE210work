using System;
using System.Collections.Generic;

public class BreathingActivity : Activity
{
    private List<string> _breathingPrompts = new List<string>();
    private BreathingPromptRandomizer _randomizer;
    private BreathingPromptTracker _tracker;

    public BreathingActivity()
        : base(
            "Breathing Activity",
            "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing."
        )
    {
        _breathingPrompts.Add("Breathe in...");
        _breathingPrompts.Add("Breathe out...");

        _randomizer = new BreathingPromptRandomizer(_breathingPrompts.Count);
        _tracker = new BreathingPromptTracker();
    }

    protected override void PerformActivity()
    {
        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

        while (DateTime.Now < endTime)
        {
            DisplayBreathingPrompt();
            ShowCountdown(3);
            Console.WriteLine();
        }
    }

    private void DisplayBreathingPrompt()
    {
        if (_randomizer.IsRoundFinished() || _tracker.AllUsed(_breathingPrompts.Count))
        {
            ResetPromptRound();
        }

        int index = _randomizer.GetNextIndex();
        _tracker.MarkUsed(index);

        Console.Write(_breathingPrompts[index] + " ");
    }

    private void ResetPromptRound()
    {
        _tracker.Reset();
        _randomizer.ShuffleOrder();
    }

    private class BreathingPromptRandomizer
    {
        private List<int> _promptIndexes = new List<int>();
        private Random _random = new Random();
        private int _currentIndex;
        private int _promptCount;

        public BreathingPromptRandomizer(int promptCount)
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

    private class BreathingPromptTracker
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




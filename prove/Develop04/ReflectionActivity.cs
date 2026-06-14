using System;
using System.Collections.Generic;
using System.Threading;

public class ReflectionActivity : Activity
{
    private List<string> _prompts = new List<string>();
    private List<string> _questions = new List<string>();

    private ReflectionPromptRandomizer _promptRandomizer;
    private ReflectionQuestionRandomizer _questionRandomizer;
    private ReflectionPromptTracker _promptTracker;
    private ReflectionQuestionTracker _questionTracker;
    private SpinnerAnimation _spinner;

    public ReflectionActivity()
        : base(
            "Reflection Activity",
            "This activity will help you reflect on times in your life when you have shown strength and resilience."
        )
    {
        _prompts.Add("Think of a time when you stood up for someone else.");
        _prompts.Add("Think of a time when you did something really difficult.");
        _prompts.Add("Think of a time when you helped someone in need.");
        _prompts.Add("Think of a time when you did something truly selfless.");

        _questions.Add("Why was this experience meaningful to you?");
        _questions.Add("Have you ever done anything like this before?");
        _questions.Add("How did you get started?");
        _questions.Add("How did you feel when it was complete?");
        _questions.Add("What made this time different than other times?");
        _questions.Add("What is your favorite thing about this experience?");
        _questions.Add("What could you learn from this experience?");
        _questions.Add("What did you learn about yourself?");
        _questions.Add("How can you keep this experience in mind in the future?");

        _promptRandomizer = new ReflectionPromptRandomizer(_prompts.Count);
        _questionRandomizer = new ReflectionQuestionRandomizer(_questions.Count);
        _promptTracker = new ReflectionPromptTracker();
        _questionTracker = new ReflectionQuestionTracker();
        _spinner = new SpinnerAnimation();
    }

    protected override void PerformActivity()
    {
        DisplayRandomPrompt();

        Console.WriteLine();
        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine();

        Console.WriteLine("Now ponder each of the following questions:");
        ShowCountdown(3);
        Console.Clear();

        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

        while (DateTime.Now < endTime)
        {
            DisplayRandomQuestion();
        }
    }

    private void DisplayRandomPrompt()
    {
        if (_promptRandomizer.IsRoundFinished() || _promptTracker.AllUsed(_prompts.Count))
        {
            ResetPromptRound();
        }

        int index = _promptRandomizer.GetNextIndex();
        _promptTracker.MarkUsed(index);

        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine($"--- {_prompts[index]} ---");
    }

    private void DisplayRandomQuestion()
    {
        if (_questionRandomizer.IsRoundFinished() || _questionTracker.AllUsed(_questions.Count))
        {
            ResetQuestionRound();
        }

        int index = _questionRandomizer.GetNextIndex();
        _questionTracker.MarkUsed(index);

        Console.WriteLine(_questions[index]);
        _spinner.Animate(5);
        Console.WriteLine();
    }

    private void ResetPromptRound()
    {
        _promptTracker.Reset();
        _promptRandomizer.ShuffleOrder();
    }

    private void ResetQuestionRound()
    {
        _questionTracker.Reset();
        _questionRandomizer.ShuffleOrder();
    }

    private class SpinnerAnimation
    {
        private List<string> _frames = new List<string>();

        public SpinnerAnimation()
        {
            _frames.Add("/");
            _frames.Add("|");
            _frames.Add("\\");
            _frames.Add("-");
        }

        public void Animate(int seconds)
        {
            DateTime endTime = DateTime.Now.AddSeconds(seconds);
            int i = 0;

            while (DateTime.Now < endTime)
            {
                Console.Write(_frames[i]);
                Thread.Sleep(250);
                Console.Write("\b \b");

                i++;
                if (i >= _frames.Count)
                {
                    i = 0;
                }
            }
        }
    }

    private class ReflectionPromptRandomizer
    {
        private List<int> _promptIndexes = new List<int>();
        private Random _random = new Random();
        private int _currentIndex;
        private int _promptCount;

        public ReflectionPromptRandomizer(int promptCount)
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

    private class ReflectionQuestionRandomizer
    {
        private List<int> _questionIndexes = new List<int>();
        private Random _random = new Random();
        private int _currentIndex;
        private int _questionCount;

        public ReflectionQuestionRandomizer(int questionCount)
        {
            _questionCount = questionCount;
            ShuffleOrder();
        }

        public void ShuffleOrder()
        {
            _questionIndexes.Clear();

            for (int i = 0; i < _questionCount; i++)
            {
                _questionIndexes.Add(i);
            }

            for (int i = 0; i < _questionIndexes.Count; i++)
            {
                int randomIndex = _random.Next(i, _questionIndexes.Count);
                int temp = _questionIndexes[i];
                _questionIndexes[i] = _questionIndexes[randomIndex];
                _questionIndexes[randomIndex] = temp;
            }

            _currentIndex = 0;
        }

        public int GetNextIndex()
        {
            if (IsRoundFinished())
            {
                ShuffleOrder();
            }

            int index = _questionIndexes[_currentIndex];
            _currentIndex++;
            return index;
        }

        public bool IsRoundFinished()
        {
            return _currentIndex >= _questionIndexes.Count;
        }
    }

    private class ReflectionPromptTracker
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

    private class ReflectionQuestionTracker
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



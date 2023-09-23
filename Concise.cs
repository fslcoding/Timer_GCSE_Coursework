using System;
using System.Timers;

public class Concise {

    static int SecondsToAnswer = 15;
    static List<char> TypedCharacters = new();
    static bool HasAnsweredPrompt = false;
    static ConsoleKeyInfo CurrentKey;

    public static void Run(string[] args) {
        StartTimer();

        Console.Clear();
        Console.WriteLine("What is the largest country by land mass?");

        while(!HasAnsweredPrompt) {
            CurrentKey = Console.ReadKey(true);

            if (CurrentKey.Key == ConsoleKey.Enter) GetAnswer();
            else if (CurrentKey.Key == ConsoleKey.Escape) return;
            else if (CurrentKey.Key == ConsoleKey.Backspace)
            {
                if (!TypedCharacters.Any()) continue;
                TypedCharacters.RemoveAt(TypedCharacters.Count - 1);
            }

            else TypedCharacters.Add(CurrentKey.KeyChar);

            Console.SetCursorPosition(0, 2);
            Console.Write("\r" + new string(' ', Console.WindowWidth - 1) + "\r");
            Console.SetCursorPosition(0, 2);
            TypedCharacters.ForEach(x => Console.Write(x));
        }
    }

    public static void StartTimer()
    {
        System.Timers.Timer timer = new System.Timers.Timer(1000);
        timer.Elapsed += UpdateTimer;
        timer.Enabled = true;
    }

    public static void UpdateTimer(object source, ElapsedEventArgs e) {
        if (HasAnsweredPrompt) return;
        if (SecondsToAnswer-- <= 0) return;

        Console.SetCursorPosition(0, 1);
        Console.WriteLine($"{SecondsToAnswer} seconds left!");
        Console.SetCursorPosition(TypedCharacters.Count, 2);
    }

    public static void GetAnswer()
    {
        Console.Write("Your answer was: ");
        TypedCharacters.ForEach(x => Console.Write(x)); 
        Environment.Exit(0);
    }
} 

using System;
using System.Timers;

public class Solution {

    // Create the timer
    static System.Timers.Timer timer;

    // Timer Length
    static int SecondsToAnswer = 15;

    // Array to store chars
    static char[] TypedCharacters = new char[0];

    static bool HasAnsweredPrompt = false;
    static ConsoleKeyInfo CurrentKey;

    public static void Main(string[] args) {

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
                char[] temp = new char[TypedCharacters.Length - 1];
                for(int i = 0; i < TypedCharacters.Length - 1; i++)
                    temp[i] = TypedCharacters[i];
                TypedCharacters = temp;
            }

            else
            {
                char[] temp = new char[TypedCharacters.Length + 1];
                for(int i = 0; i < TypedCharacters.Length; i++)
                    temp[i] = TypedCharacters[i];
                temp[^1] = CurrentKey.KeyChar;
                TypedCharacters = temp;
            }

            Console.SetCursorPosition(0, 2);
            Console.Write("\r" + new string(' ', Console.WindowWidth - 1) + "\r");
            Console.SetCursorPosition(0, 2);

            for(int i = 0; i < TypedCharacters.Length; i++)
                Console.Write(TypedCharacters[i]);
        }
    }

    public static void StartTimer()
    {
        timer = new System.Timers.Timer(1000);
        timer.Elapsed += UpdateTimer;
        timer.Enabled = true;
    }

    public static void UpdateTimer(object source, ElapsedEventArgs e) {
        if (HasAnsweredPrompt) timer.Enabled = false;
        if (SecondsToAnswer-- <= 0) return;

        Console.SetCursorPosition(0, 1);
        Console.WriteLine($"{SecondsToAnswer} seconds left!");
        Console.SetCursorPosition(TypedCharacters.Length, 2);
    }

    public static void GetAnswer()
    {
        HasAnsweredPrompt = true;
        Console.Clear();
        Console.Write("Your answer was: ");
        for (int i = 0; i < TypedCharacters.Length; i++)
            Console.Write(TypedCharacters[i]);
        Console.WriteLine();
        Console.WriteLine("You had " + SecondsToAnswer + " seconds left!");
        Environment.Exit(0);
    }
} 

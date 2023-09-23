using System;
using System.Security.Cryptography;
using System.Timers;

public class ArrayCode
{
    static int CountDown = 11; // Seconds

    static char[] TypedCharacters = new char[100];
    static int CharacterCount = 0;

    static bool AnsweredPrompt = false;
    static ConsoleKeyInfo CurrentKey;

    public static void Main(string[] args)
    {
        StartTimer();
        Console.Clear();
        Console.WriteLine("What is the largest country by land mass?");

        while (!AnsweredPrompt)
        {
            CurrentKey = Console.ReadKey(true);

            switch (CurrentKey.Key)
            {
                case(ConsoleKey.Enter):
                    CountDown = 0;
                    break;
                case(ConsoleKey.Escape):
                    Environment.Exit(0);
                    break;
                case(ConsoleKey.Delete):
                    DeleteChar();
                    break;
                case (ConsoleKey.Backspace):
                    DeleteChar();
                    break;
                default:
                    AddChar();
                    break;

            }
        }
    }

    static void RedrawAnswer()
    {
        Console.SetCursorPosition(0, 2);
        Console.Write("\n");
        Console.SetCursorPosition(0, 2);
        for (int i = 0; i < TypedCharacters.Length; i++)
        {
            if (TypedCharacters[i].Equals(""))
            {
                return;
            }
            Console.Write(TypedCharacters[i]);
        }
        Console.SetCursorPosition(CharacterCount, 2);
    }
    static void AddChar()
    {
        if (CharacterCount < TypedCharacters.Length)
        {
            TypedCharacters[CharacterCount] = CurrentKey.KeyChar;
            CharacterCount++;
            TypeNewChar();
        }
    }
    static void DeleteChar()
    {
        
        if (CharacterCount >= 1 && CharacterCount < TypedCharacters.Length)
        {
            // Create a new array with the size one less than the original array
            char[] newArray = new char[TypedCharacters.Length - 1];

            // Copy elements before the index
            for (int i = 0; i < CharacterCount - 1; i++)
            {
                newArray[i] = TypedCharacters[i];
            }

            // Copy elements after the index
            for (int i = CharacterCount - 1; i < newArray.Length; i++)
            {
                newArray[i] = TypedCharacters[i + 1];
            }

            // Update the original array with the new array
            TypedCharacters = newArray;
            CharacterCount--;
            RedrawAnswer();
        }
    }
    static void TypeNewChar()
    {
        Console.SetCursorPosition(0, 2);
        for (int i = 0; i < CharacterCount; i++)
        {
            Console.Write(TypedCharacters[i]);
        }
    }
    static void StartTimer()
    {
        System.Timers.Timer timer = new System.Timers.Timer(1000);
        timer.Elapsed += UpdateTimer;
        timer.Enabled = true;
    }

    static void UpdateTimer(object source, ElapsedEventArgs e)
    {
        if (AnsweredPrompt) return;
        if (CountDown-- <= 0)
        {
            // Put code for running out of time here
            CheckAnswer();
            AnsweredPrompt = true; // This stops the loop from continuing
            
            return;


        }
        Console.SetCursorPosition(0, 1);
        Console.WriteLine(CountDown + " Seconds Left! ");
        Console.SetCursorPosition(CharacterCount, 2);
    }
    static void CheckAnswer()
    {
        string FinalAnswer = "";

        for (int i = 0; i < CharacterCount; i++)
        {
            FinalAnswer = FinalAnswer + TypedCharacters[i];
        }
        FinalAnswer = FinalAnswer.ToLower();

        Console.Clear();
        if(FinalAnswer == "russia")
        {
            Console.WriteLine("Well done! You got the correct answer.");
        }
        else
        {
            if(FinalAnswer == "")
            {
                Console.WriteLine("Too bad. The correct answer was Russia.");
            }
            else
            {
                Console.WriteLine("Too bad. The correct answer was Russia, and you answered" + FinalAnswer);
            }
            
        }
        
    }
}
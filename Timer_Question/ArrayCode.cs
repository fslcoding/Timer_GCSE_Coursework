
using System.Timers;

namespace Timer_Question;

public class ArrayCode
{
    static int CountDown = 60; // Seconds

    static char[] TypedCharacters = new char[100];
    static int CharacterCount = 0;

    static bool AnsweredPrompt = false;
    static ConsoleKeyInfo CurrentKey;


    static void Main()
    {
        StartTimer();

        Console.WriteLine("What is Heisenberg's real name?"); 

        while(!AnsweredPrompt)
        {
            CurrentKey = Console.ReadKey(true);

            if(CurrentKey.Key == ConsoleKey.Enter)
            {
                AnsweredPrompt = true;
                break; // Exit loop 
            }

            if(CharacterCount < TypedCharacters.Length)
            {
                TypedCharacters[CharacterCount] = CurrentKey.KeyChar;
                CharacterCount++;
            }

            // Show all the characters typed so far
            Console.SetCursorPosition(0, 2);
            for(int i = 0; i < CharacterCount; i++)
            {
                Console.Write(TypedCharacters[i]);
            }

        }


        string FinalAnswer = "";

        for(int i = 0; i < CharacterCount;i++)
        {
            FinalAnswer = FinalAnswer + TypedCharacters[i];
        }

        Console.Clear();
        Console.WriteLine("Your answer was: " + FinalAnswer);

    }


    static void StartTimer() {
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
            AnsweredPrompt = true; // This stops the loop from continuing
            return;
        }

        Console.SetCursorPosition(0, 1);
        Console.WriteLine(CountDown + " Seconds Left!");
    }





}

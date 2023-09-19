using System.Timers;

namespace Timer_Question;

public class SimpleCode
{
    static int CountDown = 60; // Seconds
    static List<char> TypedCharacters = new();
    static bool AnsweredPrompt = false;
    static ConsoleKeyInfo CurrentKey;


    static void Run()
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

            Console.SetCursorPosition(0, 2);
            TypedCharacters.Add(CurrentKey.KeyChar);
            
            // Print all characters
            for(int i = 0; i < TypedCharacters.Count; i++)
            {
                Console.Write(TypedCharacters[i]);
            }

        }


        string FinalAnswer = "";

        for(int i = 0; i < TypedCharacters.Count;i++)
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



using System.Timers;

namespace Timer_Question;

public class StringCode
{
    static int CountDown = 60; // Seconds

    static bool AnsweredPrompt = false;


    // THIS DOESNT WORK


    static void Run(string[] args)
    {
        Console.Clear();
        StartTimer();

        Console.WriteLine("What is Heisenberg's real name?");

        string Answer = Console.ReadLine();

        AnsweredPrompt = true;

        // Show all the characters typed so far
        Console.SetCursorPosition(Answer.Length, 2);
        Console.WriteLine(Answer);


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





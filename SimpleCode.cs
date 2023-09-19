using System.Timers;

namespace Timer_Question;

public class SimpleCode
{
    static int CountDown = 60; // Seconds
    static List<char> AllCharacters = new();
    static bool HasAnsweredPrompt = false;
    static ConsoleKeyInfo CurrentCharacter;


    static void Run()
    {
        System.Timers.Timer timer = new(1000); // Update every second

        timer.Elapsed += UpdateTimer;
        timer.Enabled = true; // Start the clock!

        Console.WriteLine("What is Heisenberg's real name?"); 

        while(!HasAnsweredPrompt)
        {
            CurrentCharacter = Console.ReadKey(true);

            if(CurrentCharacter.Key == ConsoleKey.Enter)
            {
                HasAnsweredPrompt = true;
                break; // Exit loop 
            }

            Console.SetCursorPosition(0, 2);
            AllCharacters.Add(CurrentCharacter.KeyChar);
            
            // Print all characters
            for(int i = 0; i < AllCharacters.Count; i++)
            {
                Console.WriteLine(AllCharacters[i]);
            }

        }


        string FinalAnswer = "";

        for(int i = 0; i < AllCharacters.Count;i++)
        {
            FinalAnswer = FinalAnswer + AllCharacters[i];
        }

        Console.Clear();
        Console.WriteLine("Your answer was: " + FinalAnswer);

    }



    static void UpdateTimer(object source, ElapsedEventArgs e)
    {
        if (HasAnsweredPrompt) return;
        if (CountDown-- <= 0) return; // Put code for running out of time here 

        Console.SetCursorPosition(0, 1);
        Console.WriteLine(CountDown + " Seconds Left!");
    }





}

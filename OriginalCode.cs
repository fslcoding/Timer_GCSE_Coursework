using System.Timers;

namespace Timer_Question;

public class OriginalCode
{
    private static int CountDown = 60; // Seconds
    private static List<char> chars = new();
    private static bool HasAnswered = false;

    private static ConsoleKeyInfo currentChar;

    public static void Main(string[] args)
    {
        System.Timers.Timer timer = new(1000);

        timer.Elapsed += OnTimedEvent!;
        timer.Enabled = true;

        Console.WriteLine("What is Heisenberg's real name?");

        while(!HasAnswered)
        {
            currentChar = Console.ReadKey(true);

            if (currentChar.Key == ConsoleKey.Enter)
            {
                HasAnswered = true;
                break;
            }

            Console.SetCursorPosition(0, 2);
            chars.Add(currentChar.KeyChar.ToString()[0]);
            chars.ForEach(x => Console.Write(x));
        }


        // turn char list to string
        string answer = String.Empty;
        chars.ForEach((x) =>
        {
            answer += x;
        });
        Console.Clear();
        Console.WriteLine("Your answer was: " + answer);


    }


    static void OnTimedEvent(object source, ElapsedEventArgs e)
    {
        if (HasAnswered) return;
        if (CountDown-- <= 0) return;

        Console.SetCursorPosition(0, 1);
        Console.WriteLine(CountDown + " Seconds Left!");
    }
}

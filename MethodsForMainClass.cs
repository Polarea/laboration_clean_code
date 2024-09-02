public static class Game
{
    static string ReadConsole(string exceptionMessage)
    {
        string input = Console.ReadLine()
        ?? throw new NullReferenceException(exceptionMessage);
        return input;
    }
    public static string GetUserName()
    {
        Console.WriteLine("Enter your user name:\n");
        string name = ReadConsole("Invalid input.");
        return name;
    }

    public static void DisplayNewGameMessage()
    {
        Console.WriteLine("New game:\n");
    }

    public static void DisplayNewGame(string goal)
    {
        Console.WriteLine($"For practice, number is: {goal}\n");
    }

    public static string MakeGoal()
    {
        Random randomDigit = new Random();
        int uniqueDigit = randomDigit.Next(10);
        string fourUniqueDigits = $"{uniqueDigit}";
        for (int i = 0; i < 3; i++)
        {
            while (fourUniqueDigits.Contains($"{uniqueDigit}"))
            {
                uniqueDigit = randomDigit.Next(10);
            }
            fourUniqueDigits += $"{uniqueDigit}";
        }
        return fourUniqueDigits;
    }

    public static string GetUserGuess()
    {
        string userGuess = ReadConsole("Invalid input.");
        return userGuess;
    }

    public static string CheckUserGuess(string goal, string userGuess)
    {
        int cows = 0, bulls = 0;
        userGuess = userGuess.PadRight(4);
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (goal[i] == userGuess[j])
                {
                    if (i == j)
                    {
                        bulls++;
                    }
                    else
                    {
                        cows++;
                    }
                }
            }
        }
        return $"{"BBBB"[..bulls]},{"CCCC"[..cows]}";
    }

    public static void PlayGameUntillRightGuess(string goal, int numberOfGuesses)
    {

        string resultOfUserGuess = "";
        while (resultOfUserGuess != "BBBB,")
        {
            numberOfGuesses++;
            string userGuess = GetUserGuess();
            resultOfUserGuess = CheckUserGuess(goal, userGuess);
            Console.WriteLine(resultOfUserGuess + "\n");
        }
    }
}
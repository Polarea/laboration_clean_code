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

}
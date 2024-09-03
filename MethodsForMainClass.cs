using System.IO.Compression;
using System.Net;

public static class Game
{
    public static bool IsOn = true;
    static string name = string.Empty;
    static string goal = string.Empty;
    static string userGuess = string.Empty;
    static int numberOfGuesses;
    static string resultOfUserGuess = string.Empty;
    static readonly List<PlayerData> gameResultsList = [];

    static string ReadConsole(string exceptionMessage)
    {
        string input = Console.ReadLine()
        ?? throw new NullReferenceException(exceptionMessage);
        return input;
    }
    public static void GetUserName()
    {
        Console.WriteLine("Enter your user name:\n");
        name = ReadConsole("Invalid input.");
    }

    public static void DisplayNewGameMessage()
    {
        Console.WriteLine("New game:\n");
    }

    public static void DisplayNewGame()
    {
        Console.WriteLine($"For practice, number is: {goal}\n");
    }

    public static void MakeGoal()
    {
        Random randomDigit = new();
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
        goal = fourUniqueDigits;
    }

    static void GetUserGuess()
    {
        userGuess = ReadConsole("Invalid input.");
    }

    static void CheckUserGuess()
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
        resultOfUserGuess = $"{"BBBB"[..bulls]},{"CCCC"[..cows]}";
    }
    public static void PlayGameUntillRightGuess()
    {
        numberOfGuesses = 0;
        resultOfUserGuess = string.Empty;
        while (resultOfUserGuess != "BBBB,")
        {
            numberOfGuesses++;
            GetUserGuess();
            CheckUserGuess();
            Console.WriteLine(resultOfUserGuess + "\n");
        }
    }

    public static void SaveGameResult()
    {
        StreamWriter output = new("result.txt", append: true);
        output.WriteLine($"{name}#&#{numberOfGuesses}");
        output.Close();
    }

    public static void DisplayGameResult()
    {
        ShowTopList();
        Console.WriteLine($"Correct, it took {numberOfGuesses} guesses.");
    }

    public static void AskToContinue()
    {
        Console.WriteLine("\nContinue?");
        string answer = ReadConsole("Input is invalid!");
        if (answer != null && answer != "" && answer[..1] == "n")
        {
            IsOn = false;
        }
    }

    static void GetGameResults()
    {
        StreamReader savedResults = new("result.txt");
        string? resultLine;
        while ((resultLine = savedResults.ReadLine()) != null)
        {
            string[] separator = ["#&#"];
            string[] nameAndGuesses = resultLine.Split(separator, StringSplitOptions.None);
            string name = nameAndGuesses[0];
            int guesses = Convert.ToInt32(nameAndGuesses[1]);
            PlayerData playerData = new(name, guesses);
            int playerPositionInResultList = gameResultsList.IndexOf(playerData);
            if (playerPositionInResultList < 0)
            {
                gameResultsList.Add(playerData);
            }
            else
            {
                gameResultsList[playerPositionInResultList].Update(guesses);
            }
        }
        savedResults.Close();
        gameResultsList.Sort((playerOnPosition1, playerOnPosition2) =>
        playerOnPosition1.Average().CompareTo(playerOnPosition2.Average()));
    }

    static void ShowTopList()
    {
        GetGameResults();
        Console.WriteLine(string.Format("{0,-9}{1,8}{2,9}", "Player", "games", "average"));
        foreach (PlayerData player in gameResultsList)
        {
            Console.WriteLine(string.Format("{0,-9}{1,5:D}{2,9:F2}", player.Name, player.Score, player.Average()));
        }
    }
}
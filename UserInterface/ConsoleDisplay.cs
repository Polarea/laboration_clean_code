public class ConsoleDisplay : IDisplay
{
    public bool AskToContinue()
    {
        Console.WriteLine("\nContinue?");
        string? answer = Console.ReadLine();
        if (answer != null && answer != "" && answer[..1] == "n")
            return false;
        else return true;
    }

    public void DisplayGameResult(int gameScore)
    {
        Console.WriteLine($"Correct, it took {gameScore} guesses.\n");
    }

    public void DisplayNewGame(string newGame)
    {
        Console.WriteLine($"For practice, number is: {newGame}\n");
    }

    public void DisplayNewGameMessage()
    {
        Console.WriteLine("New game:\n");
    }

    public string GetUserName()
    {
        string? name = null;
        while (name == null)
        {
            Console.WriteLine("Enter your user name:\n");
            name = Console.ReadLine();
        }
        return name;
    }

    public string GetUserGuess()
    {
        string? userGuess = Console.ReadLine();
        return userGuess ?? "";
    }

    public void DisplayTopList(List<PlayerData> topList)
    {
        Console.WriteLine(string.Format("{0,-9}{1,8}{2,9}", "Player", "games", "average"));
        foreach (PlayerData data in topList)
        {
            Console.WriteLine(string.Format("{0,-9}{1,5:D}{2,9:F2}", data.Name, data.NumberOfGames, data.Average()));
        }
    }
}
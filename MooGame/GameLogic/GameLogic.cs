using System.Reflection.Metadata.Ecma335;

public class GameLogic : IGameLogic
{
    string goal = string.Empty;
    string resultOfUserGuess = string.Empty;
    public string MakeGoal()
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
        return goal;
    }

    public string CheckUserGuess(string userGuess = "")
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
        return resultOfUserGuess;
    }

    public List<PlayerData> MakeTopList(List<PlayerData> scoreList)
    {
        scoreList.Sort((playerOnPosition1, playerOnPosition2) =>
        playerOnPosition1.Average().CompareTo(playerOnPosition2.Average()));
        return scoreList;
    }
}
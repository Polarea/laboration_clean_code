public interface IDisplay
{
    string GetUserName();
    void DisplayNewGameMessage();
    void DisplayNewGame(string newGame);
    string GetUserGuess();
    void DisplayGameResult(int gameScore);
    void DisplayTopList(List<PlayerData> topList);
    bool AskToContinue();
}
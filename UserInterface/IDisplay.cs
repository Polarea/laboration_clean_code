public interface IDisplay
{
    string GetUserName();
    void DisplayNewGameMessage();
    void DisplayNewGame(string newGame);
    string GetUserGuess();
    void DisplayGameResult(int gameScore);
    void DisplayTopList(List<IGameData> topList);
    bool AskToContinue();
}
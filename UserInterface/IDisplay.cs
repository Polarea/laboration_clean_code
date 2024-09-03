public interface IDisplay
{
    string GetUserName();
    void DisplayNewGameMessage();
    void DisplayNewGame(string newGame);
    void DisplayGameResult(int gameScore);
    void DisplayTopList(List<IData> topList);
    bool AskToContinue();
}
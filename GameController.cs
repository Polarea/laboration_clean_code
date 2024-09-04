public class GameController
{
    IGameDataHandler _dataHandler;
    IDisplay _display;
    IGameLogic _gameLogic;
    public GameController(IGameDataHandler dataHandler, IDisplay display, IGameLogic gameLogic)
    {
        _dataHandler = dataHandler;
        _display = display;
        _gameLogic = gameLogic;
    }

    public void PlayGame()
    {
        bool gameIsOn = true;
        string name = _display.GetUserName();
        int numberOfGuesses = 0;
        while (gameIsOn)
        {
            string goal = _gameLogic.MakeGoal();
            _display.DisplayNewGameMessage();
            _display.DisplayNewGame(goal);
            numberOfGuesses = PlayGameUntillRightGuess(numberOfGuesses);
            _dataHandler.SaveScore(name, numberOfGuesses);
            var scoreList = _dataHandler.GetScore();
            _display.DisplayGameResult(numberOfGuesses);
            _display.DisplayTopList(scoreList);
            gameIsOn = _display.AskToContinue();
            numberOfGuesses = 0;
        }
    }

    int PlayGameUntillRightGuess(int numberOfGuesses)
    {
        string resultOfUserGuess;
        do
        {
            numberOfGuesses++;
            string userGuess = _display.GetUserGuess();
            resultOfUserGuess = _gameLogic.CheckUserGuess(userGuess);
            Console.WriteLine(resultOfUserGuess + "\n");
        }
        while (resultOfUserGuess != "BBBB,");
        return numberOfGuesses;
    }
}
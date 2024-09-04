public class GameDataInFile : IGameDataHandler
{
    public List<IGameData> GetScore()
    {
        StreamReader savedResults = new("result.txt");
        List<IGameData> _listData = [];
        string? resultLine;
        while ((resultLine = savedResults.ReadLine()) != null)
        {
            string[] separator = ["#&#"];
            string[] nameAndGuesses = resultLine.Split(separator, StringSplitOptions.None);
            string name = nameAndGuesses[0];
            int guesses = Convert.ToInt32(nameAndGuesses[1]);
            PlayerData playerData = new(name, guesses);
            int playerPositionInResultList = _listData.IndexOf(playerData);
            if (playerPositionInResultList < 0)
            {
                _listData.Add(playerData);
            }
            else
            {
                _listData[playerPositionInResultList].Update(guesses);
            }
        }
        savedResults.Close();
        return _listData;
    }

    public void SaveScore(string name, int score)
    {
        StreamWriter output = new("result.txt", append: true);
        output.WriteLine($"{name}#&#{score}");
        output.Close();
    }

}
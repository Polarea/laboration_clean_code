public class PlayerDataFile : IPlayerDataHandler
{
    public List<PlayerData> GetScore()
    {
        StreamReader savedResults = new("result.txt");
        List<PlayerData> _playerDataList = [];
        string? resultLine;
        while ((resultLine = savedResults.ReadLine()) != null)
        {
            string[] separator = ["#&#"];
            string[] nameAndGuesses = resultLine.Split(separator, StringSplitOptions.None);
            string name = nameAndGuesses[0];
            int guesses = Convert.ToInt32(nameAndGuesses[1]);
            PlayerData playerData = new(name, guesses);
            var playerInList = _playerDataList.Find(playerInList => playerInList.Equals(playerData));
            if (playerInList != null)
            {
                playerInList.Update(guesses);
            }
            else
            {
                _playerDataList.Add(playerData);
            }
        }
        savedResults.Close();
        return _playerDataList;
    }

    public void SaveScore(string name, int score)
    {
        StreamWriter output = new("result.txt", append: true);
        output.WriteLine($"{name}#&#{score}");
        output.Close();
    }

}

public class DataInFile : IDataHandler
{
    IData _data;
    List<IData> _listData = [];

    public DataInFile(IData data)
    {
        _data = data;
    }

    public List<IData> GetScore()
    {
        StreamReader savedResults = new("result.txt");
        string? resultLine;
        while ((resultLine = savedResults.ReadLine()) != null)
        {
            string[] separator = ["#&#"];
            string[] nameAndGuesses = resultLine.Split(separator, StringSplitOptions.None);
            string name = nameAndGuesses[0];
            int guesses = Convert.ToInt32(nameAndGuesses[1]);
            int playerPositionInResultList = _listData.IndexOf(_data);
            if (playerPositionInResultList < 0)
            {
                _listData.Add(_data);
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
public interface IDataHandler
{
    void SaveScore(string name, int score);
    List<IData> GetScore();
}
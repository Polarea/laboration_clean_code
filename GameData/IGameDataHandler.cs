public interface IGameDataHandler
{
    void SaveScore(string name, int score);
    List<IGameData> GetScore();
}
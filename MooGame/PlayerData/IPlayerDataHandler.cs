public interface IPlayerDataHandler
{
    void SaveScore(string name, int score);
    List<PlayerData> GetScore();
}
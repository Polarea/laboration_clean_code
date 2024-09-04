public interface IGameData
{
    string Name { get; }
    int Score { get; }
    void Update(int data);
    double Average();
}
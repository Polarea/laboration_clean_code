public interface IData
{
    string Name { get; }
    int Score { get; }
    void Update(int data);
    double Average();
}
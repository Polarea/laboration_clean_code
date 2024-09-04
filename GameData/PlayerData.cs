public class PlayerData : IGameData
{
    public string Name { get; private set; } = "";
    public int Score { get; private set; }
    int totalGuess;


    public PlayerData(string name, int guesses)
    {
        Name = name;
        Score = 1;
        totalGuess = guesses;
    }

    public void Update(int guesses)
    {
        totalGuess += guesses;
        Score++;
    }

    public double Average()
    {
        return (double)totalGuess / Score;
    }


    public override bool Equals(Object? otherObject)
    {
        if (otherObject is PlayerData playerScore)
            return Name.Equals(playerScore.Name);
        else return false;
    }


    public override int GetHashCode()
    {
        return Name.GetHashCode();
    }
}
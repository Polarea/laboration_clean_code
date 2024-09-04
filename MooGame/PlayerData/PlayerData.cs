public class PlayerData
{
    public string Name { get; private set; } = "";
    public int NumberOfGames { get; private set; }
    int totalGuesses;
    public PlayerData(string name, int guesses)
    {
        Name = name;
        NumberOfGames = 1;
        totalGuesses = guesses;
    }
    public void Update(int guesses)
    {
        totalGuesses += guesses;
        NumberOfGames++;
    }
    public double Average()
    {
        return (double)totalGuesses / NumberOfGames;
    }
    public override bool Equals(Object? otherObject)
    {
        if (otherObject is PlayerData playerData)
            return Name.Equals(playerData.Name);
        else return false;
    }

    public override int GetHashCode()
    {
        return Name.GetHashCode();
    }
}
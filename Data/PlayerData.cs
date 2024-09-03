public class PlayerData : IData
{
    public string Name { get; private set; }
    public int Data { get; private set; }
    int totalGuess;


    public PlayerData(string name, int guesses)
    {
        Name = name;
        Data = 1;
        totalGuess = guesses;
    }

    public void Update(int guesses)
    {
        totalGuess += guesses;
        Data++;
    }

    public double Average()
    {
        return (double)totalGuess / Data;
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
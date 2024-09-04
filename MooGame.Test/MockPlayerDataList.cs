namespace MooGame.Test;

public class MockPlayerDataList
{
    public List<PlayerData> playerDataUnsortedList = new()
    {
        new PlayerData("testUser1", 4),
        new PlayerData("testUser2", 1),
        new PlayerData("testUser3", 3),
        new PlayerData("testUser4", 5),
        new PlayerData("testUser5", 2),
    };

    public List<PlayerData> playerDataSortedList = new()
    {
        new PlayerData("testUser2", 1),
        new PlayerData("testUser5", 2),
        new PlayerData("testUser3", 3),
        new PlayerData("testUser1", 4),
        new PlayerData("testUser4", 5),
    };
}

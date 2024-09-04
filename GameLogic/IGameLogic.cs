public interface IGameLogic
{
    string MakeGoal();
    string CheckUserGuess(string userGuess);
    List<PlayerData> MakeTopList(List<PlayerData> scoreList);
}
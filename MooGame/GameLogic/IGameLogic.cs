public interface IGameLogic
{
    string MakeGoal();
    string CheckUserGuess(string goal, string userGuess);
    List<PlayerData> MakeTopList(List<PlayerData> scoreList);
}
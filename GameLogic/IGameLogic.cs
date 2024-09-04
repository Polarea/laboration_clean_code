public interface IGameLogic
{
    string MakeGoal();
    string CheckUserGuess(string userGuess);
    List<IGameData> MakeTopList(List<IGameData> scoreList);
}
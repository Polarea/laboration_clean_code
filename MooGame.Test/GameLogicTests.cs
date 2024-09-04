using Newtonsoft.Json.Bson;

namespace MooGame.Test;

[TestClass]
public class GameLogicTests
{
    static GameLogic _gameLogic = new();
    string goal = _gameLogic.MakeGoal();

    [TestMethod]
    public void GoalShouldBeFourDigitLong()
    {
        var expectedLength = 4;
        Assert.AreEqual(expectedLength, goal.Length);
    }

    [TestMethod]
    public void GoalShouldBeAString()
    {
        var expectedType = "String";
        Assert.AreEqual(expectedType, goal.GetType().Name);
    }

    [TestMethod]
    public void GoalShouldHaveUniqueDigits()
    {
        var expectedLength = 4;
        Assert.AreEqual(expectedLength, goal.Distinct().Count());
    }

    [TestMethod]
    [DataRow("0123", "", ",")]
    [DataRow("1234", "2", ",C")]
    [DataRow("2345", "34", ",CC")]
    [DataRow("3456", "456", ",CCC")]
    [DataRow("4567", "7654", ",CCCC")]
    [DataRow("5678", "5867", "B,CCC")]
    [DataRow("6789", "6798", "BB,CC")]
    [DataRow("7890", "7890", "BBBB,")]
    public void CheckResultShouldBeCorrect(string goal, string guess, string checkResult)
    {
        string correctResult = _gameLogic.CheckUserGuess(goal, guess);
        Assert.AreEqual(checkResult, correctResult);
    }
}
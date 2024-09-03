using System;
using System.IO;
using System.Collections.Generic;

class MainClass
{

	public static void Main(string[] args)
	{
		Game.GetUserName();

		while (Game.IsOn)
		{
			Game.MakeGoal();
			Game.DisplayNewGameMessage();
			Game.DisplayNewGame();
			Game.PlayGameUntillRightGuess();
			Game.SaveGameResult();
			Game.DisplayGameResult();
			Game.AskToContinue();
		}
	}
}
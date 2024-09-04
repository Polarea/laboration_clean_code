class MainClass
{

	public static void Main(string[] args)
	{
		GameController gameController = new(
			new PlayerDataFile(),
			new ConsoleDisplay(),
			new GameLogic()
		);
		gameController.PlayGame();
	}
}
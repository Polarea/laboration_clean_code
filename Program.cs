class MainClass
{

	public static void Main(string[] args)
	{
		GameController gameController = new(
			new GameDataInFile(),
			new ConsoleDisplay(),
			new GameLogic()
		);
		gameController.PlayGame();
	}
}
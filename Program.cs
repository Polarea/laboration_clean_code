using System;
using System.IO;
using System.Collections.Generic;

class MainClass
{

	public static void Main(string[] args)
	{
		bool playOn = true;
		string name = Game.GetUserName();

		while (playOn)
		{
			string goal = Game.MakeGoal();
			int numberOfGuesses = 0;
			Game.DisplayNewGameMessage();
			Game.DisplayNewGame(goal);
			Game.PlayGameUntillRightGuess(goal, numberOfGuesses);
			StreamWriter output = new StreamWriter("result.txt", append: true);
			output.WriteLine(name + "#&#" + numberOfGuesses
			);
			output.Close();
			showTopList();
			Console.WriteLine("Correct, it took " + numberOfGuesses
			 + " guesses\nContinue?");
			string answer = Console.ReadLine();
			if (answer != null && answer != "" && answer.Substring(0, 1) == "n")
			{
				playOn = false;
			}
		}
	}

	static void showTopList()
	{
		StreamReader input = new StreamReader("result.txt");
		List<PlayerData> results = new List<PlayerData>();
		string line;
		while ((line = input.ReadLine()) != null)
		{
			string[] nameAndScore = line.Split(new string[] { "#&#" }, StringSplitOptions.None);
			string name = nameAndScore[0];
			int guesses = Convert.ToInt32(nameAndScore[1]);
			PlayerData pd = new PlayerData(name, guesses);
			int pos = results.IndexOf(pd);
			if (pos < 0)
			{
				results.Add(pd);
			}
			else
			{
				results[pos].Update(guesses);
			}


		}
		results.Sort((p1, p2) => p1.Average().CompareTo(p2.Average()));
		Console.WriteLine("Player   games average");
		foreach (PlayerData p in results)
		{
			Console.WriteLine(string.Format("{0,-9}{1,5:D}{2,9:F2}", p.Name, p.NGames, p.Average()));
		}
		input.Close();
	}
}

class PlayerData
{
	public string Name { get; private set; }
	public int NGames { get; private set; }
	int totalGuess;


	public PlayerData(string name, int guesses)
	{
		this.Name = name;
		NGames = 1;
		totalGuess = guesses;
	}

	public void Update(int guesses)
	{
		totalGuess += guesses;
		NGames++;
	}

	public double Average()
	{
		return (double)totalGuess / NGames;
	}


	public override bool Equals(Object p)
	{
		return Name.Equals(((PlayerData)p).Name);
	}


	public override int GetHashCode()
	{
		return Name.GetHashCode();
	}
}
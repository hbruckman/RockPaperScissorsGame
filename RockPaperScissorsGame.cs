namespace RockPaperScissorsGame;

public class RockPaperScissorsGame
{
	public static readonly int ROCK = 0;
	public static readonly int PAPER = 1;
	public static readonly int SCISSORS = 2;

	public static readonly string[] MOVES = { "Rock", "Paper", "Scissors" };

	private int pMove;
	private int cMove;

	public static void Main(string[] args)
	{
		RockPaperScissorsGame game = new RockPaperScissorsGame();
	}

	public RockPaperScissorsGame()
	{
		int input;

		Init();

		ShowGameStartScreen();

		do
		{
			ShowBoard();

			do
			{
				ShowInputOptions();
				input = GetInput();
			}
			while (!IsValidInput(input));

			ProcessInput(input);

			UpdateGameState();
		}
		while (!IsGameOver());

		ShowGameOverScreen();
	}

	public void Init()
	{

	}

	public void ShowGameStartScreen()
	{
		Console.WriteLine("Welcome to Rock-Paper-Scissors!");
	}

	public void ShowBoard()
	{
		Console.WriteLine("Rock... Paper... Scissors!");
	}

	public void ShowInputOptions()
	{
		Console.Write($"[{ROCK}] Rock | [{PAPER}] Paper | [{SCISSORS}] Scissors > ");
	}

	public int GetInput()
	{
		return (int.TryParse(Console.ReadLine(), out int input)) ? input : -1;
	}

	public bool IsValidInput(int input)
	{
		if (input != ROCK && input != PAPER && input != SCISSORS)
		{
			Console.WriteLine("Invalid input.");

			return false;
		}
		else
		{
			return true;
		}
	}

	public void ProcessInput(int input)
	{
		pMove = input;

		Console.WriteLine($"Player Move: {MOVES[pMove]}");
	}

	public void UpdateGameState()
	{
		Random rnd = new Random();

		cMove = rnd.Next(3);

		Console.WriteLine($"Skynet Move: {MOVES[cMove]}");
	}

	public bool IsGameOver()
	{
		if (pMove == cMove)
		{
			Console.WriteLine("Again!");

			return false;
		}
		else
		{
			return true;
		}
	}

	public void ShowGameOverScreen()
	{
		if ((pMove == ROCK && cMove == SCISSORS) || (pMove == PAPER && cMove == ROCK) || (pMove == SCISSORS && cMove == PAPER))
		{
			Console.WriteLine("You won!");
		}
		else
		{
			Console.WriteLine("You lost!");
		}
	}
}

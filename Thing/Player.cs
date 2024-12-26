namespace IFDotNet;

public class Player : Person
{
	public List<IMove> Moves = new()
	{
		new LookMove(),
		new QuitGame(),
	};

	public Dictionary<string, string> Aliases = new()
	{
		{ "l", "look" },
		{ "exit", "quit" },
	};

	public Player(string name = "Player") : base(name)
	{
	}

	public List<string> StartCommands = new() { "look" };

	public IMove? GetMove(string command)
	{
		foreach(IMove move in Moves)
		{
			if (move.Command == command)
			{
				return move;
			}
		}

		return null;
	}
}

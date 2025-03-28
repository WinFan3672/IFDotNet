namespace IFDotNet;

/// <summary>The player object</summary>
public class Player : Person
{
	/// <summary>The commands the player can run</summary>
	/// <remarks>IF.NET calls commands moves</remarks>
	/// <seealso cref="IMove" />
	public List<IMove> Moves = new()
	{
		new LookMove(),
		new QuitGame(),
		new GoMove(),
		new SayMove(),
	};

	/// <summary>Command aliases</summary>
	/// <seealso cref="IMove" />
	public Dictionary<string, string> Aliases = new()
	{
		{ "l", "look" },
		{ "exit", "quit" },

		{ "north", "go south" },
		{ "northeast", "go northeast" },
		{ "north-east", "go northeast" },
		{ "east", "go east" },
		{ "southeast", "go south-east" },
		{ "south-east", "go south-east" },
		{ "south", "go south" },
		{ "southwest", "go southwest" },
		{ "south-west", "go southwest" },
		{ "west", "go west" },
		{ "northwest", "go northwest" },
		{ "north-west", "go northwest" },
		{ "up", "go up" },
		{ "down", "go down" },

		{ "n", "go north" },
		{ "ne", "go northeast" },
		{ "e", "go east" },
		{ "se", "go southeast" },
		{ "s", "go south" },
		{ "sw", "go southwest" },
		{ "w", "go west" },
		{ "nw", "go northwest" },
		{ "u", "go up" },
		{ "d", "go down" },

		{ "yes", "say yes" },
		{ "no", "say no" },
	};

	///
	public Player(string name = "Player") : base(name)
	{
	}

	/// <summary>Commands run at the start of the game</summary>
	public List<string> StartCommands = new() { "look" };

	/// <summary>Gets a <see cref="IMove" /> from a command string</summary>
	/// <remarks>This function is called by <see cref="Runner.Run" /> and is of little consequence to story developers</remarks>
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

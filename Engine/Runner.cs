namespace IFDotNet;
using Spectre.Console;

/// <summary>
/// Game runner
/// </summary>
public static class Runner
{
	/// <summary>
	/// Runs game.
	/// </summary>
	/// <param name="world">World to run</param>
	/// <exception cref="ArgumentException">World has no rooms</exception>
	/// <remarks>Start by creating a <see cref="World"/> and go from there</remarks>
	/// <seealso cref="Spectre.Console"/>
	public static void Run(World world)
	{
		if (world.Rooms.Count == 0)
		{
			throw new ArgumentException("World has no rooms");
		}

		GameState gs = new(world.Rooms[0]);

		string Command;
		List<string> SplitCommand;
		List<string> Args;

		//Console.Clear();
		if (world.AuthorialModesty)
		{
			AnsiConsole.MarkupLine($"[bold]{world.StoryTitle}[/]");
		}
		else
		{
			AnsiConsole.MarkupLine($"[bold]{world.StoryTitle}[/] by {world.StoryAuthor}");
		}

		AnsiConsole.MarkupLine(world.Description);

		Console.WriteLine();
		foreach(string command in world.Player.StartCommands)
		{
			SplitCommand = command.Split(" ").ToList();
			Args = SplitCommand.GetRange(1, SplitCommand.Count - 1);
			RunCommand(SplitCommand[0], Args.ToArray(), world, gs);

		}

		while (true)
		{
			Console.Write("> ");
			Command = Console.ReadLine() ?? "";

			SplitCommand = Command.Split(" ").ToList();
			Args = SplitCommand.GetRange(1, SplitCommand.Count - 1);

			try
			{
				RunCommand(SplitCommand[0], Args.ToArray(), world, gs);
			}
			catch (ErrorMessageException Ex)
			{
				Console.WriteLine(Ex.Message);
				/*AnsiConsole.MarkupLine($"[bold red]error[/]: {Ex.Message}");*/
			}
			catch (PlayerDeathException Ex)
			{
				Console.WriteLine(Ex.Message);
                AnsiConsole.MarkupLine("[bold red]You died![/]");
                Console.Write("Press any key to exit the game.");
				Console.ReadKey();
				return;
			}
		}
	}

	private static void RunCommand(CommandArgPair pair, World world, GameState gs)
		{
			RunCommand(pair.Command, pair.Args, world, gs);
		}

	private static void RunCommand(string command, string[] args, World world, GameState gs)
	{
		if (world.Player.Aliases.Keys.Contains(command))
		{
			RunCommand(new CommandArgPair(world.Player.Aliases[command]), world, gs);
			return; // If omitted it will try executing the alias without parsing it
		}

		IMove move = world.Player.GetMove(command) ?? throw new ErrorMessageException("Sorry, I don't understand that verb.");
		move.Run(args, world.Player, gs.CurrentRoom, gs);
	}
}

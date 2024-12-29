namespace IFDotNet;
using Spectre.Console;

public static class Runner
{
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

		Console.Clear();
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
		}
	}

	private static void RunCommand(string command, string[] args, World world, GameState gs)
	{
		if (world.Player.Aliases.Keys.Contains(command))
		{
			RunCommand(world.Player.Aliases[command], args, world, gs);
			return; // If omitted it will try executing the alias without parsing it
		}

		IMove move = world.Player.GetMove(command) ?? throw new ErrorMessageException("Sorry, I don't understand that verb.");
		move.Run(args, world.Player, gs.CurrentRoom, gs);
	}
}

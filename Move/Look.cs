namespace IFDotNet;
using Spectre.Console;

/// <summary>Look around</summary>
public class LookMove : IMove
{
	///
	public string Command {get; set; } = "look";

	///
	public void Run(string[] Args, Player player, Room room, GameState gameState)
	{
		AnsiConsole.MarkupLine($"[bold]{room.Name}[/]");
		Console.WriteLine(room.Description);

		foreach (Thing thing in room.Things)
		{
			Console.WriteLine($"You can see {thing.Name} here.");
		}
	}
}

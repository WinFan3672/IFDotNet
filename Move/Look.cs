namespace IFDotNet;
using Spectre.Console;

/// <summary>Look around</summary>
public class LookMove : IMove
{
	///
	public string Command {get; set; } = "look";

	/// <inheritdoc />
	public void Run(string[] Args, Player player, Room room, GameState gameState)
	{
		if (Args.Length == 0)
		{
			if (room.Name != String.Empty)
			{
				AnsiConsole.MarkupLine($"[bold]{room.Name}[/]");
			}
			if (room.Description != String.Empty)
			{
				Console.WriteLine(room.Description);
			}

			foreach (Thing thing in room.Things)
			{
				Console.WriteLine($"You can see {thing.Name} here.");
			}

			room.OnLook();
		}
		else if (Args.Length == 1)
		{
			Thing? thing = room.FindThing(Args[0], false);
			if (thing == null)
				throw new ErrorMessageException("I can't see that anywhere.");
			Console.WriteLine(thing.Description);
		}
		else if (Args.Length == 2 && Args[0] == "at")
		{
			// This is an edge case for when the player uses 'look at'
			Run(Args[1..], player, room, gameState);
		}
		else
			throw new ErrorMessageException("I don't understand you.");
		
	}
}

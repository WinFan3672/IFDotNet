namespace IFDotNet;

public class ClearScreen : IMove
{
	public string Command {get; set; } = "clear";

	public void Run(string[] Args, Player player, Room room, GameState gameState)
	{
	}
}

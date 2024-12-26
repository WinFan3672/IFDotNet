namespace IFDotNet;

public class QuitGame : IMove
{
	public string Command { get; set; } = "quit";

	public void Run(string[] args, Player player, Room room, GameState state)
	{
		Environment.Exit(0);
	}
}

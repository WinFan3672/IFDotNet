namespace IFDotNet;

/// <summary>
/// Quits game
/// </summary>
public class QuitGame : IMove
{
	/// <inheritdoc/>
	public string Command { get; set; } = "quit";

	/// <inheritdoc/>
	public void Run(string[] args, Player player, Room room, GameState state)
	{
		Environment.Exit(0);
	}
}

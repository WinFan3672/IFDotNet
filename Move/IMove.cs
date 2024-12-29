namespace IFDotNet;

/// <summary>Base move interface</summary>
public interface IMove
{
	/// <summary>Command name</summary>
	public string Command {get; set; }

	/// <summary>Called when move is run</summary>
	public void Run(string[] Args, Player player, Room room, GameState gameState);
}


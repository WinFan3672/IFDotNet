namespace IFDotNet;

public interface IMove
{
	public string Command {get; set; }

	public void Run(string[] Args, Player player, Room room, GameState gameState);
}

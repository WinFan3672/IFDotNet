namespace IFDotNet;

/// <summary>Say something</summary>
public class SayMove : IMove
{
	///
	public string Command {get; set; } = "say";

	///
	public void Run(string[] args, Player player, Room room, GameState gs)
	{
		Console.WriteLine(string.Join(' ', args));
	}
}

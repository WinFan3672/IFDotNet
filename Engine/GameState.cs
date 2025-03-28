namespace IFDotNet;

/// <summary>
/// Game state
/// </summary>
///
/// <remarks>
/// Only the game engine has access to the GameState, meaning events like <see cref="MovePlayerEvent" /> are used to control game state.
/// </remarks>
public class GameState
{
	/// <summary>
	/// Current room occupied by the player
	/// </summary>
	public Room CurrentRoom;

	///
	public GameState(Room startingRoom)
	{
		CurrentRoom = startingRoom;
	}
}


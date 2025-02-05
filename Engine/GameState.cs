namespace IFDotNet;

/// <summary>
/// Game state machine
/// </summary>
public class GameState
{
	/// <summary>
	/// Current room the player is occupying
	/// </summary>
	public Room CurrentRoom;
    /// 
    public GameState(Room startingRoom)
	{
		CurrentRoom = startingRoom;
	}
}


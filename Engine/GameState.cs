namespace IFDotNet;

public class GameState
{
	public Room CurrentRoom;

	public GameState(Room startingRoom)
	{
		CurrentRoom = startingRoom;
	}
}


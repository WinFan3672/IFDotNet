namespace IFDotNet;

public class Room
{
	public string Name {get; private set; }
	public List<Thing> Things = new();
	public Dictionary<Direction, Room?> Connections = new()
	{
		{ Direction.North, null },
		{ Direction.NorthEast, null },
		{ Direction.East, null },
		{ Direction.SouthEast, null },
		{ Direction.South, null },
		{ Direction.SouthWest, null },
		{ Direction.West, null },
		{ Direction.NorthWest, null },
	};

	public string Description {get; private set; }

	public Room(string name, string description)
	{
		Name = name;
		Description = description;
	}

	public void Connect(Direction dir, Room room)
	{
		Connections[dir] = room;
	}
}

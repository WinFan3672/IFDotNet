namespace IFDotNet;

/// <summary>A room in the world</summary>
public class Room
{
	/// <summary>Name</summary>
	public string Name {get; private set; }

	/// <summary>Things in the room</summary>
	/// <seealso cref="Thing" />
	/// <seealso cref="Person" />
	public List<Thing> Things = new();

	/// <summary>All rooms connected to this room</summary>
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
		{ Direction.Up, null },
		{ Direction.Down, null },
	};

	/// <summary>Room description</summary>
	public string Description {get; private set; }

	private bool hasEnter = false;
	private bool hasExit = false;

	/// <summary>
	/// Per-room event bus
	/// </summary>
	public EventBus Events = new();

	/// <summary>
	/// Called every time the player enters the room
	/// </summary>
	public Action<Room> OnEnter = (Room room) => { if (!room.hasEnter) { room.OnFirstEnter(room); } };

	/// <summary>
	/// Called every time the player exits the room
	/// </summary>
	public Action<Room> OnExit = (Room room) => { if(!room.hasExit) { room.OnFirstExit(room); } };

	/// <summary>
	/// Called the first time the player enters the room
	/// </summary>
	public Action<Room> OnFirstEnter = (Room room) => { room.hasEnter = true; };

	/// <summary>
	/// Called the first time the player exits the room
	/// </summary>
	public Action<Room> OnFirstExit = (Room room) => { room.hasExit = true; };

	///
	public Room(string name, string description)
	{
		Name = name;
		Description = description;
	}

	private Direction GetOpposite(Direction dir)
	{
		var currentIndex = (int)dir;
		var oppositeIndex = (currentIndex + 4) % 8;
		Console.WriteLine(currentIndex);
		Console.WriteLine(oppositeIndex);
		return (Direction)Enum.GetValues(typeof(Direction)).GetValue(oppositeIndex);
	}

	/// <summary>Connects a room to this room, letting you move between them</summary>
	/// <param name="dir">Direction to connect in (e.g. <see cref="Direction.South" /> of this room)</param>
	/// <param name="room">Room to connect</param>
	/// <param name="autoConnect">Whether to automatically connect this room to the room you're adding (so that you can go back)</param>
	/// <remarks>It is not necessary to add a room that is connected to another room to <see cref="World.Rooms" /> unless you want to be able to teleport the player/an item(s) there</remarks>
	public void Connect(Direction dir, Room room, bool autoConnect = true)
	{
		Connections[dir] = room;
		if (autoConnect)
		{
			room.Connections[GetOpposite(dir)] = this;
		}
	}
}

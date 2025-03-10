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
	/// <summary>
	/// The people occupying the room.
	/// </summary>
	public List<Person> Occupants = new();
	private static Random random = new Random();


    private bool Entered = false;
	private bool Left = false;

    /// <summary>
    ///  Called when entering the room.
    /// </summary>
	/// <remarks>The Room value is the current room</remarks>
    public Action<Room> OnEnter = (room) => {
		if (!room.Entered)
		{
			room.Entered = true;
			room.OnFirstEnter();
		}
	};
	/// <summary>
	/// Called when entering for the first time only.
	/// </summary>
	public Action OnFirstEnter = () => { };
	/// <summary>
	/// Called when leaving a room for the first time only.
	/// </summary>
	public Action OnFirstLeave = () => { };
	/// <summary>
	/// Called when running the 'look' command (without looking at something in particular).
	/// </summary>
	public Action OnLook = () => { };
	/// <summary>
	/// Called when leaving the room.
	/// </summary>
	public Action<Room> OnLeave = (room) => {
		if (!room.Left)
		{
			room.Left = true;
			room.OnFirstLeave();
		}
	};

	// TODO: Add the room as an argument in CheckEnter and CheckLeave

	/// <summary>
	/// Called to check if a player can enter a room.
	/// </summary>
	public Func<bool> CheckEnter = () => { return true; };
	/// <summary>
	/// Called to check if a player can leave a room.
	/// </summary>
	public Func<bool> CheckLeave = () => { return true; };

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
	};

	/// <summary>Room description</summary>
	public string Description {get; private set; }

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
#pragma warning disable CS8605 // Unboxing a possibly null value.
        return (Direction)Enum.GetValues(typeof(Direction)).GetValue(oppositeIndex);
#pragma warning restore CS8605 // Unboxing a possibly null value.
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

	/// <summary>
	/// Adds a thing to the room.
	/// </summary>
	public void Add(Thing thing)
	{ 
		Things.Add(thing);
	}

    /// <summary>
    /// Finds a thing in a room from its name
    /// </summary>
    /// <param name="name">The name of the thing</param>
    /// <param name="strictMatch">Case sensitivity.</param>
    /// <returns>The first instance of a <see cref="Thing"/> with a matching name</returns>
    public Thing? FindThing(string name, bool strictMatch = true)
	{
		foreach (var thing in Things)
		{
			// Loose match - case insensitive and supports substring matching
			// TODO: Make sure substring is at least one whole word long
			if (thing.Name == name || !strictMatch && thing.Name.ToLower().Contains(name.ToLower()))
			{
				return thing;
			}
		}
		return null;
	}

	/// <summary>
	/// Selects a random compass direction that is not connected to a room
	/// </summary>
	/// <returns></returns>
	/// <exception cref="ArgumentNullException"></exception>
	public Direction PickDir(bool diagonal = true)
	{
		var dirs = Enum.GetValues(typeof(Direction));
		int index = random.Next(dirs.Length);
		if (!diagonal && index % 2 != 0)
		{
			// This relies on the fact that the indexes for the non-diagonal compass directions are even
			index--;
		}
		Direction dir = dirs.GetValue(index) as Direction? ?? throw new ArgumentNullException();
		if (Connections[dir] != null) // Is connected
			return PickDir();
		else
			return dir;
			
	}

	/// <summary>
	/// Removes a thing from the room.
	/// </summary>
	/// <param name="thing">Thing to remove</param>
	public void Remove(Thing thing)
	{
		Things.Remove(thing);
	}
}

namespace IFDotNet;

/// <summary>The game world</summary>
public class World
{
	/// <summary>Rooms in the world</summary>
	/// <remarks>Not all rooms are added here, since most rooms need only be connected to another room</remarks>
	public List<Room> Rooms = new();

	/// <summary>Story title</summary>
	public string StoryTitle {get; private set; }
	
	/// <summary>Story author</summary>
	public string StoryAuthor {get; private set; }

	/// <summary>Player object</summary>
	public Player Player {get; set; }

	/// <summary>Story description</summary>
	public string Description {get; private set; }

	/// <summary>If set to <code>true</code>, the author is not shown when first running the game</summary>
	public bool AuthorialModesty = false;

	/// <summary>Called when the game is started</summary>
	/// <seealso cref="Action" />
	public Action OnStart = () => {};

	///
	public World(string storyTitle, string storyAuthor, Player player, string description)
	{
		StoryTitle = storyTitle;
		StoryAuthor = storyAuthor;
		Player = player;
		Description = description;
	}

	/// <summary>Add a room</summary>
	/// <seealso cref="Room" />
	public void Add(Room room)
	{
		Rooms.Add(room);
	}
}

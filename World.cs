namespace IFDotNet;

public class World
{
	public List<Room> Rooms = new();
	public string StoryTitle {get; private set; }
	public string StoryAuthor {get; private set; }
	public Player Player {get; set; }

	public string Description {get; private set; }

	public bool AuthorialModesty = false;

	public Action OnStart = () => {};

	public World(string storyTitle, string storyAuthor, Player player, string description)
	{
		StoryTitle = storyTitle;
		StoryAuthor = storyAuthor;
		Player = player;
		Description = description;
	}
}

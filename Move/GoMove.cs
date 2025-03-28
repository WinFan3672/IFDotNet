namespace IFDotNet;

/// <summary>Move that moves the player in a connected direction</summary>
public class GoMove : IMove
{
	///
	public string Command {get; set; } = "go";

	///
	public void Run(string[] args, Player player, Room room, GameState gs)
	{
		if (args.Length == 0)
		{
			Console.WriteLine("go [north/south/east/west]");
			return;
		}
		else if (args.Length != 1)
		{
			throw new ErrorMessageException("Invalid syntax");
		}
		else
		{
			string move = args[0].ToLower();
			switch(move)
			{
				case "n":
				case "north":
					Go(Direction.North, player, room, gs);
					break;
				case "ne":
				case "northeast":
				case "north-east":
					Go(Direction.NorthEast,  player, room, gs);
					break;
				case "e":
				case "east":
					Go(Direction.East, player, room, gs);
					break;
				case "se":
				case "south-east":
				case "southeast":
					Go(Direction.SouthEast, player, room, gs);
					break;
				case "s":
				case "south":
					Go(Direction.South, player, room, gs);
					break;
				case "sw":
				case "southwest":
				case "south-west":
					Go(Direction.SouthWest, player, room, gs);
					break;
				case "w":
				case "west":
					Go(Direction.West, player, room, gs);
					break;
				case "nw":
				case "northwest":
				case "north-west":
					Go(Direction.NorthWest, player, room, gs);
					break;
				case "u":
				case "up":
					Go(Direction.Up, player, room, gs);
					break;
				case "d":
				case "down":
					Go(Direction.Down, player, room, gs);
					break;
				default:
					throw new ErrorMessageException("I don't know which way *that* is.");
			}
		}

		void Go(Direction dir, Player player, Room room, GameState gs)
		{
			if (room.Connections[dir] == null)
				throw new ErrorMessageException("There's nothing that way.");
			gs.CurrentRoom.OnExit(gs.CurrentRoom); // Call OnExit() for previous room
			gs.CurrentRoom = room.Connections[dir] ?? throw new ArgumentNullException();
			gs.CurrentRoom.OnEnter(gs.CurrentRoom); // Call OnEnter() for next room

			IMove lookMove = player.GetMove("look") ?? throw new ArgumentNullException("LookMove is not in Player.Moves");
			lookMove.Run(new string[] {}, player, gs.CurrentRoom, gs);
		}
	}
}

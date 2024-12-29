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

			// This is unwieldy but there are eight directions and a variable amount of string values, so...
			// Maybe a 'better' solution would be a Dictionary<string[], Direction>
			if (move == "n" || move == "north")
			{
				Go(Direction.North, player, room, gs);
			}
			else if (move == "ne" || move == "northeast" || move == "north-east")
			{
				Go(Direction.NorthEast, player, room, gs);
			}
			else if (move == "e" || move == "east")
			{
				Go(Direction.East, player, room, gs);
			}
			else if (move == "se" || move == "south-east" || move == "southeast")
			{
				Go(Direction.SouthEast, player, room, gs);
			}
			else if (move == "s" || move == "south")
			{
				Go(Direction.South, player, room, gs);
			}
			else if (move == "sw" || move == "southwest" || move == "south-west")
			{
				Go(Direction.SouthWest, player, room, gs);
			}
			else if (move == "w" || move == "west")
			{
				Go(Direction.West, player, room, gs);
			}
			else if (move == "nw" || move == "northwest" || move == "north-west")
			{
				Go(Direction.NorthWest, player, room, gs);
			}
			else
			{
				throw new ErrorMessageException("I don't know which way *that* is");
			}
		}

		void Go(Direction dir, Player player, Room room, GameState gs)
		{
			if (room.Connections[dir] == null)
			{
				throw new ErrorMessageException("There's nothing that way.");
			}
			else
			{
				gs.CurrentRoom = room.Connections[dir] ?? throw new ArgumentNullException();
			}

			IMove lookMove = player.GetMove("look") ?? throw new ArgumentNullException("LookMove is not in Player.Moves");
			lookMove.Run(new string[] {}, player, gs.CurrentRoom, gs);
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IFDotNet;

/// <summary>
/// Talk to a person
/// </summary>
public class TalkMove : IMove
{
    /// <inheritdoc/>
    public string Command { get; set; } = "talk";
    /// <inheritdoc/>
    public void Run(string[] args, Player player, Room room, GameState gameState)
    {
        if (args.Length == 0)
            throw new ErrorMessageException("I don't know who you want to talk to.");
        else if (args.Length > 0 && args[0] == "to")
            Run(args[1..], player, room, gameState);
        else
        {
            string Name = String.Join(' ', args);
            Person? person = room.FindThing(String.Join(' ', args), false) as Person;
            if (person == null)
                throw new ErrorMessageException($"I can't see {Name} anywhere.");
            if (person.Tree != null)
                person.Tree.Run();
            else
                Console.WriteLine($"You try talking to {Name}. You get no response.");
        }
    }
}

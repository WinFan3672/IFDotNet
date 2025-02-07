using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IFDotNet;

public  class GrabMove : IMove
{
    public string Command { get; set; } = "grab";

    public void Run(string[] args, Player player, Room room, GameState gameState)
    {
        if (args.Length == 0)
            throw new ErrorMessageException("You cannot grab the room.");
        else
        {
            Thing thing = room.FindThing(String.Join(' ', args), false) ?? throw new ErrorMessageException("I can't see that anywhere.");
            if (thing.CheckGrab())
            {
                // Remove from room
                room.Remove(thing);
                // Add to inventory
                player.Inventory.Add(thing);
            }
            else
                throw new ErrorMessageException("You can't grab that.");
        }
    }
}
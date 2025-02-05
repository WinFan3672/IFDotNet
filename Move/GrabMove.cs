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

    }
}
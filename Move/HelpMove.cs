using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IFDotNet;

/// <summary>
/// Prints command help.
/// </summary>
public class HelpMove : IMove
{
    public string Command { get; set; } = "help";
    /// <inheritdoc/>
    public void Run(string[] args, Player player, Room room, GameState gameState)
    {
    }
}


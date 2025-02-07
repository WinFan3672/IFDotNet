using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFDotNet
{
    internal struct CommandArgPair
    {
        public string Command;
        public string[] Args;

        internal CommandArgPair(string command, string[] args)
        {
            Command = command;
            Args = args;
        }

        /// <summary>
        /// Ingests a string containing a command and argument(s)
        /// </summary>
        /// <param name="command">Command and arguments</param>
        internal CommandArgPair(string command)
        {
            string[] parts = command.Split(' ');
            Command = parts[0];
            Args = parts[1..];
        }
    }
}

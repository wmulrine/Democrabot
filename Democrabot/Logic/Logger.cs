using Discord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Democrabot.Logic
{
    internal static class Logger
    {
        internal static Task Log(LogMessage msg)
        {
            Console.WriteLine($"Log: {msg}");
            return Task.CompletedTask;
        }
    }
}

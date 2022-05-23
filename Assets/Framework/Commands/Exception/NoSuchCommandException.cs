using System;

namespace Framework.Commands
{
    public class NoSuchCommandException : Exception
    {
        public override string Message { get; } = "No such command";
    }
}
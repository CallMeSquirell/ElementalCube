using System;

namespace Framework.Commands
{
    public class CommandInfo : ICommandInfo
    {
        public Type BindedType { get; }
        
        public CommandInfo(Type bindedType)
        {
            BindedType = bindedType;
        }
    }
}
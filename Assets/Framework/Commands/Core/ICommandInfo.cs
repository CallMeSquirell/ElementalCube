using System;

namespace Framework.Commands
{
    public interface ICommandInfo
    {
        Type BindedType { get; }
    }
}
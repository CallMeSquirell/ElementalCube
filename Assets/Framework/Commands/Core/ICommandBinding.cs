using System;

namespace Framework.Commands
{
    public interface ICommandBinding
    {
        ICommandInfo Info { get; }
        void To<TBind>() where TBind : ICommand;
    }
}
using System;

namespace Framework.Commands
{
    public class CommandBinding<T> : ICommandBinding
    {
        public ICommandInfo Info { get; private set; }

        public void To<TBind>() where TBind : ICommand
        {
            Info = new CommandInfo(typeof(TBind));
        }
    }
}
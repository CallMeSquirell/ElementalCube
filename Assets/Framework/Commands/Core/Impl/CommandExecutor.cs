using System;
using Framework.Promises;

namespace Framework.Commands
{
    public class CommandExecutor : ICommandExecutor
    {
        private readonly ICommandBinder _commandBinder;
        private readonly ICommandFactory _commandFactory;

        public CommandExecutor(ICommandBinder commandBinder, 
            ICommandFactory commandFactory)
        {
            _commandBinder = commandBinder;
            _commandFactory = commandFactory;
        }

        public IPromise Execute<T>() where T : IExecutableCommand
        {
            if (_commandBinder.TryGetBind<T>(out ICommandBinding binding) && 
                _commandFactory.Create(binding.Info) is T executableCommand)
            {
                executableCommand.Execute();
                return executableCommand.Promise;
            }
            throw new NoSuchCommandException();
        }
        
        public IPromise Execute<T>(ICommandPayload payload) where T : IExecutableCommand<ICommandPayload>
        {
            if (_commandBinder.TryGetBind<T>(out ICommandBinding binding) && 
                _commandFactory.Create(binding.Info) is T executableCommand)
            {
                executableCommand.Execute(payload);
                return executableCommand.Promise;
            }
            throw new NoSuchCommandException();
        }
    }
}
using System;

namespace Framework.Commands.ExecutableQueue
{
    public class QueuedCommand : IQueuedCommand
    {
        public event Action<bool> Completed;
        private readonly ICommand _command;
        private readonly ICommandPayload _payload;

        public QueuedCommand(ICommand command, ICommandPayload payload = null)
        {
            _command = command;
            _payload = payload;
        }

        public void Execute()
        {
            _command.Promise.Then(OnComplete)
                .Fail(OnFailed);
            Invoke();
        }
        
        private void OnComplete()
        {
            Completed?.Invoke(true);
        }

        private void OnFailed()
        {
            Completed?.Invoke(false);
        }
        
        private void Invoke()
        {
            switch (_command)
            {
                case IExecutableCommand<ICommandPayload> executableCommandWithPayload:
                    executableCommandWithPayload.Execute(_payload);
                    break;
                case IExecutableCommand executableCommand:
                    executableCommand.Execute();
                    break;
            }
        }

        public void Dispose()
        {
            _command.Dispose();
        }
    }
}
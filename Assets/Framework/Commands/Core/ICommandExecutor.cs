using Framework.Promises;

namespace Framework.Commands
{
    public interface ICommandExecutor
    {
        IPromise Execute<T>() where T : IExecutableCommand;
        IPromise Execute<T>(ICommandPayload payload) where T : IExecutableCommand<ICommandPayload>;
    }
}
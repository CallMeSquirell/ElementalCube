using System;
using Framework.Promises;

namespace Framework.Commands
{
    public interface ICommand : IDisposable
    {
        IPromise Promise { get; }
    }
    
    public interface IExecutableCommand : ICommand
    {
        void Execute();
    }
    
    public interface IExecutableCommand<T> : ICommand where T : ICommandPayload
    {
        void Execute(T payload);
    }
}
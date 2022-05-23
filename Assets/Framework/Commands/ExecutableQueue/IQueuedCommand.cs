using System;

namespace Framework.Commands.ExecutableQueue
{
    public interface IQueuedCommand : IDisposable
    {
        event Action<bool> Completed;
        void Execute();
    }
}
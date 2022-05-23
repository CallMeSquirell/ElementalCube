using System;

namespace Framework.Commands.ExecutableQueue
{
    public interface ICommandQueue : IDisposable
    {
        bool AutoExecute { get; set; }
        bool IsPlaying { get;}
        void Add<T>(ICommandPayload payload, int priority) where T : BaseCommand, IExecutableCommand<ICommandPayload>;
        void Add<T>(int priority) where T : BaseCommand, IExecutableCommand;
        void AddTrigger<T>(int priority) where T : IExecutableCommand;
        void AddTrigger<T>(ICommandPayload payload, int priority) where T : IExecutableCommand<ICommandPayload>;
        void Play();
        void Stop();
    }
}
using System.Collections.Generic;

namespace Framework.Commands.ExecutableQueue
{
    public class PriorityComparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            return y - x;
        }
    }

    internal class CommandQueue : ICommandQueue
    {
        public bool AutoExecute { get; set; }
        public bool IsPlaying { get; set; }

        private readonly ICommandFactory _commandFactory;
        private readonly ICommandBinder _commandBinder;


        private IPriorityQueue<int, IQueuedCommand> _priorityQueue;
        private IQueuedCommand _currentCommand;

        public CommandQueue(ICommandFactory commandFactory, ICommandBinder commandBinder)
        {
            _commandFactory = commandFactory;
            _commandBinder = commandBinder;
            _priorityQueue = new PriorityQueue<int, IQueuedCommand>(new PriorityComparer());
        }


        public void Add<T>(ICommandPayload payload, int priority)
            where T : BaseCommand, IExecutableCommand<ICommandPayload>
        {
            var command = _commandFactory.Create(new CommandInfo(typeof(T)));
            var queuedCommand = new QueuedCommand(command, payload);
            _priorityQueue.Enqueue(priority, queuedCommand);
            if (AutoExecute)
            {
                Play();
            }
        }

        public void Add<T>(int priority) where T : BaseCommand, IExecutableCommand
        {
            var command = _commandFactory.Create(new CommandInfo(typeof(T)));
            var queuedCommand = new QueuedCommand(command);
            _priorityQueue.Enqueue(priority, queuedCommand);
            if (AutoExecute)
            {
                Play();
            }
        }

        public void AddTrigger<T>(int priority) where T : IExecutableCommand
        {
            if (_commandBinder.TryGetBind<T>(out ICommandBinding commandBinding))
            {
                var command = _commandFactory.Create(commandBinding.Info);
                var queuedCommand = new QueuedCommand(command);
                _priorityQueue.Enqueue(priority, queuedCommand);
                if (AutoExecute)
                {
                    Play();
                }
            }
        }

        public void AddTrigger<T>(ICommandPayload payload, int priority) where T : IExecutableCommand<ICommandPayload>
        {
            if (_commandBinder.TryGetBind<T>(out ICommandBinding commandBinding))
            {
                var command = _commandFactory.Create(commandBinding.Info);
                var queuedCommand = new QueuedCommand(command, payload);
                _priorityQueue.Enqueue(priority, queuedCommand);
                if (AutoExecute)
                {
                    Play();
                }
            }
        }

        public void Play()
        {
            IsPlaying = true;
            TryExecuteNext();
        }

        public void Stop()
        {
            IsPlaying = false;
        }

        private void TryExecuteNext()
        {
            if (_currentCommand != null || !IsPlaying || _priorityQueue.IsEmpty)
            {
                IsPlaying = false;
                return;
            }

            _currentCommand = _priorityQueue.Dequeue();
            _currentCommand.Completed += OnCommandCompleted;
        }

        private void OnCommandCompleted(bool success)
        {
            _currentCommand.Completed -= OnCommandCompleted;
            _currentCommand = null;
            
            if (success)
            {
                TryExecuteNext();
            }
            else
            {
                Stop();
            }
        }

        public void Dispose()
        {
            _priorityQueue.Clear();
        }
    }
}
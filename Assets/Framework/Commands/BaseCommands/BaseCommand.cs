using Framework.Promises;

namespace Framework.Commands
{
    public abstract class BaseCommand : ICommand
    {
        public IPromise Promise { get; } = new Promise();
        
        protected void Release()
        {
            Promise.Dispatch();
        }

        protected void Abort()
        {
            Promise.Abort();
        }

        public virtual void Dispose(){}
    }
}
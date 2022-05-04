using System;

namespace Framework.Promises
{
    public class PromiseAction : Promise
    {
        private Func<IPromise> _action;
        
        public PromiseAction()
        {
            
        }
        
        public PromiseAction(IPromise promise)
        {
            promise.BindTo(this);
        }
        
        public PromiseAction(Func<IPromise> action)
        {
            _action = action;
        }
        
        public virtual void Execute()
        {
            if (_action != null)
            {
                _action.Invoke().BindTo(this);
            }            
        }
    }
}
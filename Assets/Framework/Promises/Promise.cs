using System;

namespace Framework.Promises
{
    public class Promise : IPromise
    {
        private Action _thenAction;
        private Action _failAction;
        private Action<float> _progressAction;
        private Action _onComplete;

        protected bool Completed { get; private set; }
        protected bool Successfully { get; private set; }

        public void Dispatch()
        {
            _thenAction?.Invoke();
            Successfully = true;
            Complete();
        }

        public void Abort()
        {
            _failAction?.Invoke();
            Successfully = false;
            Complete();
        }
        
        private void Complete()
        {
            Completed = true;
            _onComplete?.Invoke();
            SetProgress(1f);
            Clear();
        }


        public void SetProgress(float value)
        {
            _progressAction?.Invoke(value);
        }

        public void BindTo(IPromise promise)
        {
            _thenAction += promise.Dispatch;
            _failAction += promise.Abort;
        }

        public IPromise Then(Action action)
        {
            _thenAction += action;
            if (Completed)
            {
                AlreadyComplete();
            }
            return this;
        }
        
        public IPromise Fail(Action action)
        {
            _failAction += action;
            if (Completed)
            {
                AlreadyComplete();
                return this;
            }
           
            return this;
        }

        public IPromise Finally(Action action)
        {
            _onComplete += action;
            if (Completed)
            {
                AlreadyComplete();
                return this;
            }
            return this;
        }
        
        public IPromise Progress(Action<float> action)
        {
            _progressAction += action;
            return this;
        }
        
        private void AlreadyComplete()
        {
            if (Successfully)
            {
                Dispatch();
            }
            else
            {
                Abort();
            }
        }
        
        protected virtual void Clear()
        {
            _thenAction = null;
            _onComplete = null;
            _failAction = null;
            _progressAction = null;
        }
    }

    public class Promise<T> : Promise, IPromise<T>
    {
        private Action<T> _onComplete;
        private T _result;

        public IPromise<T> Then(Action<T> action)
        {
            _onComplete += action;
            if (Completed)
            {
                AlreadyComplete(_result);
                return this;
            }
            return this;
        }

        public void Dispatch(T payload)
        {
            _result = payload;
            _onComplete?.Invoke(payload);
            base.Dispatch();
        }
        
        private void AlreadyComplete(T payload)
        {
            if (Successfully)
            {
                Dispatch(payload);
            }
            else
            {
                Abort();
            }
        }

        protected override void Clear()
        {
            base.Clear();
            _onComplete = null;
        }
    }
}
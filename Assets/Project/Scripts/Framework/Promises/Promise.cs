using System;
using System.Collections.Generic;

namespace Project.Scripts.Framework.Promises
{
    public class Promise : IPromise
    {
        private readonly List<Action> _thenAction = new List<Action>();
        private readonly List<Action> _failAction = new List<Action>();
        private readonly List<Action> _progressAction = new List<Action>();
        private readonly List<Action> _onComplete = new List<Action>();

        public void Dispatch()
        {
            _thenAction.ForEach(action => action?.Invoke());
            Complete();
        }

        public void Abort()
        {
            _failAction.ForEach(action => action?.Invoke());
            Complete();
        }

        public void SetProgress()
        {
            _progressAction.ForEach(action => action?.Invoke());
        }

        public IPromise Then(Action action)
        {
            _thenAction.Add(action);
            return this;
        }

        public IPromise Fail(Action action)
        {
            _failAction.Add(action);
            return this;
        }

        public IPromise Progress(Action action)
        {
            _progressAction.Add(action);
            return this;
        }

        public IPromise Finally(Action action)
        {
            _onComplete.Add(action);
            return this;
        }

        private void Complete()
        {
            _onComplete.ForEach(action => action?.Invoke());
            Clear();
        }

        private void Clear()
        {
            _thenAction.Clear();
            _onComplete.Clear();
            _failAction.Clear();
            _progressAction.Clear();
        }
    }
}
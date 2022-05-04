using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace Framework.Promises
{
    public class PromiseActionQueue : PromiseAction
    {
        private readonly Queue<PromiseAction> _queue = new Queue<PromiseAction>();

        private readonly bool _autoStart;
        private readonly bool _ignoreError;
        
        private bool _isPlaying;
        
        private PromiseAction _currentAction;

        public bool IsPlaying => _isPlaying;

        public PromiseAction CurrentAction => _currentAction;

        public PromiseActionQueue(bool isAutoStart = false, bool ignoreError = false)
        {
            _autoStart = isAutoStart;
            _ignoreError = ignoreError;
        }

        public PromiseActionQueue Append([NotNull] PromiseAction action)
        {
            _queue.Enqueue(action);
            if (_autoStart)
            {
                Do();
            }
            return this;
        }

        public void Do()
        {
            if (!_isPlaying)
            {
                _isPlaying = true;
                PlayNext();   
            }
        }
        
        private void PlayNext()
        {
            if (_queue.Count > 0) 
            {
                _currentAction = _queue.Dequeue();
                _currentAction
                    .Then(PlayNext)
                    .Fail(OnFailed);
                _currentAction.Execute();
            }
            else
            {
                Dispatch();
                _isPlaying = false;
            }
        }
        
        private void OnFailed()
        {
            if (_ignoreError)
            {
                PlayNext();
            }
            else
            {
                Abort();
                Debug.LogError($"Promise queue failed {_currentAction}");
                _isPlaying = false;   
            }
        }
    }
}
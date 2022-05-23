using System;
using System.Collections.Generic;
using Zenject;

namespace Project.Scripts.GameControl.Watchers
{
    public class WatcherManager : IWatcherManager
    {
        private readonly IInstantiator _instantiator;
        private readonly Dictionary<Type, IWatcher> _watchers = new Dictionary<Type, IWatcher>();

        public WatcherManager(IInstantiator instantiator)
        {
            _instantiator = instantiator;
        }

        public void Register<T>() where T : IWatcher
        {
            if (!_watchers.ContainsKey(typeof(T)))
            {
                var watcher =_instantiator.Instantiate<T>();
                watcher.Initialise();
                _watchers.Add(typeof(T), watcher);
            }
        }

        public void Deregister<T>() where T : IWatcher
        {
            if (_watchers.TryGetValue(typeof(T), out IWatcher watcher))
            {
                watcher.Dispose();
                _watchers.Remove(typeof(T));
            }
        }
    }
}
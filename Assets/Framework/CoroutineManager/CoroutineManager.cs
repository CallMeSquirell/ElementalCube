using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Framework.CoroutineManager
{
    public class CoroutineManager : ICoroutineManager
    {
        private readonly List<Coroutine> _activeCoroutines = new List<Coroutine>();
        
        private Runner _runner;

        private Runner Runner => _runner != null ? _runner : _runner = PrepareRunner();
        
        public Coroutine Start(IEnumerator method)
        {
            var coroutine = Runner.StartCoroutine(method);
            _activeCoroutines.Add(coroutine);
            return coroutine;
        }

        public void Stop(Coroutine coroutine)
        {
            Runner.StopCoroutine(coroutine);
            _activeCoroutines.Remove(coroutine);
        }

        private Runner PrepareRunner()
        {
            var obj = new GameObject("Coroutine runner");
            var component = obj.AddComponent<Runner>();
            Object.DontDestroyOnLoad(obj);
            return component;
        }
        
    }
}
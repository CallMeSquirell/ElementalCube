using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Scripts.Framework.Manager
{
    public class CoroutineManager : ICoroutineManager
    {
        private readonly List<Coroutine> _activeCoroutines = new List<Coroutine>();

        private MonoBehaviour _runner;

        private MonoBehaviour Runner => _runner != null ? _runner : _runner = PrepareRunner();
        
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

        private MonoBehaviour PrepareRunner()
        {
            var obj = new GameObject("Coroutine runner");
            var component = obj.AddComponent<MonoBehaviour>();
            Object.DontDestroyOnLoad(obj);
            return component;
        }
        
    }
}
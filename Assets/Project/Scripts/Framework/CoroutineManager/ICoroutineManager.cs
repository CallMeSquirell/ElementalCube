using System.Collections;
using UnityEngine;

namespace Project.Scripts.Framework.Manager
{
    public interface ICoroutineManager
    {
        Coroutine Start(IEnumerator method);
        void Stop(Coroutine coroutine);
    }
}
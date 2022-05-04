using System.Collections;
using UnityEngine;

namespace Framework.CoroutineManager
{
    public interface ICoroutineManager
    {
        Coroutine Start(IEnumerator method);
        void Stop(Coroutine coroutine);
    }
}
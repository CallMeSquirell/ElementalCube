using Framework.Promises;
using UnityEngine;

namespace Framework.UI.Animations
{
    public abstract class BaseTransition : MonoBehaviour
    {
        public IPromise PlayCloseTransition()
        {
            var promise = new Promise();
            Close(promise);
            return promise;
        }

        public IPromise PlayOpenTransition()
        {
            var promise = new Promise();
            Open(promise);
            return promise;
        }

        protected abstract void Open(IPromise promise);
        protected abstract void Close(IPromise promise);
    }
}
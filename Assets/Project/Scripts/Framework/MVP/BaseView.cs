using UnityEngine;
using Zenject;

namespace Project.Scripts.Framework.MVP
{
    public abstract class BaseView<T> : MonoBehaviour
    {
        private T _data;
        private IInstantiator _instantiator;

        public T Data => _data;

        protected IInstantiator Instantiator => _instantiator;

        [Inject]
        private void Construct(IInstantiator instantiator)
        {
            _instantiator = instantiator;
        }

        public void SetData(T data)
        {
            if (_data != null)
            {
                UnBind();
            }
            _data = data;
            Initialize();
        }
        
        protected virtual void Initialize() { }
        
        protected virtual void UnBind() { }
    }
}
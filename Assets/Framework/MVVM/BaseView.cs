using Framework.ResourceManagement;
using UnityEngine;
using Zenject;

namespace Framework.MVVM
{
    public abstract class BaseView<T> : MonoBehaviour
    {
        private T _data;
        private IInstantiator _instantiator;
        private IAssetManager _assetManager;
        private IConfig _config;

        public T Data => _data;

        protected IInstantiator Instantiator => _instantiator;

        protected IAssetManager AssetManager => _assetManager;

        protected IConfig Config => _config;

        [Inject]
        private void Construct(IInstantiator instantiator, IAssetManager assetManager, IConfig config)
        {
            _instantiator = instantiator;
            _assetManager = assetManager;
            _config = config;
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
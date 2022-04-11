using Project.Scripts.Framework.MVP.DI.Provider;
using Project.Scripts.Framework.MVP.UI.Views;
using Project.Scripts.Framework.ResourceManagement;
using UnityEngine;
using Zenject;

namespace Project.Scripts.GameControl.Loader
{
    public class LevelLoader : MonoBehaviour
    {
        private IInstantiator _instantiator;
        private IPresenterProvider _provider;
        private IConfig _config;
        private Level _currentLevel;
        
        [Inject]
        private void Construct(IInstantiator instantiator, IPresenterProvider provider, IConfig config)
        {
            _config = config;
            _instantiator = instantiator;
            _provider = provider;
        }

        private void Awake()
        {
            var level = _instantiator.InstantiatePrefab(_config.Get<LevelConfig>().Level);
            foreach (var view in  level.GetComponentsInChildren<WindowWindowView>())
            {
                _provider.ProvideIncludeSubViesTo(view);
            }
        }
    }
}
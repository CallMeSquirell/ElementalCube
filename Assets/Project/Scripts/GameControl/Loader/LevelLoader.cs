using Project.Scripts.Framework.MVP.DI.Provider;
using Project.Scripts.Framework.MVP.Views;
using Project.Scripts.Framework.ResourceManagement;
using Project.Scripts.GamePlay.LevelSystem;
using UnityEngine;
using Zenject;

namespace Project.Scripts.GameControl.Loader
{
    public class LevelLoader : MonoBehaviour
    {
        private IInstantiator _instantiator;
        private IPresenterProvider _provider;
        private Level _currentLevel;
        
        [Inject]
        private void Construct(IInstantiator instantiator, IPresenterProvider provider)
        {
            _instantiator = instantiator;
            _provider = provider;
        }

        private void Awake()
        {
            var level = _instantiator.InstantiatePrefab(Config.Get<LevelConfig>().Level);
            foreach (var view in  level.GetComponentsInChildren<ManagedView>())
            {
                _provider.ProvideIncludeSubViesTo(view);
            }
        }
    }
}
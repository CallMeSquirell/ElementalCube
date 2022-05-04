using Framework.Promises;
using Framework.ResourceManagement;
using Framework.UI.Manager;
using Project.Scripts.Framework.ResourceManagement;
using Project.Scripts.GamePlay.LevelSystem;
using Zenject;

namespace Project.Scripts.GameControl.Loader
{
    public class LevelLoader : ILevelLoader
    {
        private readonly IInstantiator _instantiator;
        private readonly Level _currentLevel;
        private readonly IConfig _assetManager;
        private readonly IUIManager _uiManager;

        public LevelLoader(IInstantiator instantiator, IConfig assetManager, IUIManager uiManager)
        {
            _instantiator = instantiator;
            _assetManager = assetManager;
            _uiManager = uiManager;
        }

        public IPromise Load()
        {
            return _assetManager.Load().Then(() =>
            {
                var config = _assetManager.Get<LevelConfig>();
                _instantiator.InstantiatePrefab(config.Level);
                _uiManager.OpenView(RegisteredViews.GameScreen);
            }); 
        }
    }
}
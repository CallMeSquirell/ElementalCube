using Framework.Promises;
using Framework.UI.Manager;
using Project.Scripts.Configs;
using Project.Scripts.Constants;
using Project.Scripts.GameControl.Loader;
using Project.Scripts.GamePlay.Models;
using UnityEngine;
using Zenject;

namespace Project.Scripts.GameControl
{
    public class BootstrapController : IInitializable
    {
        private readonly ILevelLoader _levelLoader;
        private readonly IConfig _config;
        private readonly IUIManager _uiManager;
        private readonly IPlayerModel _playerModel;

        public BootstrapController(ILevelLoader levelLoader,
            IConfig config, 
            IUIManager uiManager,
            IPlayerModel playerModel)
        {
            _levelLoader = levelLoader;
            _config = config;
            _uiManager = uiManager;
            _playerModel = playerModel;
        }

        public void Initialize()
        {
            var queue = new PromiseActionQueue();
            queue.Append(new PromiseAction(_config.Load));
            queue.Append(new PromiseAction(() => _levelLoader.LoadNextLevel(_playerModel.CurrentLevel.LevelNumber)
                .Then(OnLevelLoaded)));
            queue.Do();
        }

        private void OnLevelLoaded()
        {
            _uiManager.Initialise();
            _uiManager.OpenView(RegisteredViews.StartScreen);   
            DestroyLoadingScreen();
        }

        private void DestroyLoadingScreen()
        {
            var loadingScreen = GameObject.FindWithTag("LoadingScreen");
            Object.Destroy(loadingScreen);
        }
    }
}
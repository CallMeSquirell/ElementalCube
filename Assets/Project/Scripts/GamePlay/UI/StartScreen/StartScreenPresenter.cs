using Framework.UI.Manager;
using Framework.UI.MVP.Views.Core;
using Project.Scripts.Constants;
using Project.Scripts.GameControl.Loader;
using Project.Scripts.GameControl.Models;
using Project.Scripts.GameControl.Watchers;
using Project.Scripts.GamePlay.Models;

namespace Project.Scripts.GamePlay.UI.StartScreen
{
    public class StartScreenPresenter : Presenter<StartScreenView>
    {
        private readonly IUIManager _uiManager;
        private readonly ILevelLoader _levelLoader;
        private readonly IPlayerModel _playerModel;
        private readonly IInGameEnergyModel _energyModel;
        private readonly IEnemyModel _enemyModel;
        private readonly ITownHallModel _townHallModel;
        private readonly ICubeSetModel _cubeSetModel;
        private readonly IWatcherManager _watcherManager;

        public StartScreenPresenter(StartScreenView view,
            IUIManager uiManager,
            ILevelLoader levelLoader,
            IPlayerModel playerModel,
            IInGameEnergyModel energyModel,
            IEnemyModel enemyModel, 
            ITownHallModel townHallModel,
            ICubeSetModel cubeSetModel,
            IWatcherManager watcherManager) : base(view)
        {
            _uiManager = uiManager;
            _levelLoader = levelLoader;
            _playerModel = playerModel;
            _energyModel = energyModel;
            _enemyModel = enemyModel;
            _townHallModel = townHallModel;
            _cubeSetModel = cubeSetModel;
            _watcherManager = watcherManager;
        }

        public override void Initialise()
        {
            View.PlayClicked += OnPlayClicked;
            _levelLoader.SetUpNextLevel();
            View.SetLevelNumber(_playerModel.CurrentLevel.LevelNumber);
            View.SetEnemyPreview(_playerModel.CurrentLevel.Packs);
        }

        private void OnPlayClicked()
        {
            ResetModels();
            RegisterWatchers();
            _enemyModel.SetEnemyPack(_playerModel.CurrentLevel.Packs);
            _uiManager.OpenView(RegisteredViews.GameScreen).Opened.Then(OnGameScreenOpened);
        }

        private void ResetModels()
        {
            _cubeSetModel.RefreshAvailableCubeDataList();
            _energyModel.FullFill();
            _townHallModel.Reset();
        }

        private void RegisterWatchers()
        {
            _watcherManager.Register<GameEndWatcher>();
            _watcherManager.Register<EnergyWatcher>();
        }

        private void OnGameScreenOpened()
        {
            _levelLoader.CreatedLevel.EnemySpawner.Play();
        }

        public override void Dispose()
        {
            View.PlayClicked -= OnPlayClicked;
        }
    }
}
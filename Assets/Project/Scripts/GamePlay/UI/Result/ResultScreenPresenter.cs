using Framework.UI.Manager;
using Framework.UI.MVP.Views.Core;
using Project.Scripts.Constants;
using Project.Scripts.GameControl;
using Project.Scripts.GameControl.Loader;
using Project.Scripts.GameControl.Watchers;
using Project.Scripts.GamePlay.Models;

namespace Project.Scripts.GamePlay.UI.Result
{
    public class ResultScreenPresenter : Presenter<ResultScreenView>
    {
        private readonly ResultScreenPayload _payload;
        private readonly ILevelLoader _levelLoader;
        private readonly IPlayerModel _playerModel;
        private readonly IUIManager _uiManager;
        private readonly IWatcherManager _watcherManager;

        public ResultScreenPresenter(ResultScreenView view, 
            ResultScreenPayload payload,
            ILevelLoader levelLoader, 
            IPlayerModel playerModel,
            IUIManager uiManager, 
            IWatcherManager watcherManager
        ) : base(view)
        {
            _payload = payload;
            _levelLoader = levelLoader;
            _playerModel = playerModel;
            _uiManager = uiManager;
            _watcherManager = watcherManager;
        }

        public override void Initialise()
        {
            _watcherManager.Deregister<GameEndWatcher>();
            _watcherManager.Deregister<EnergyWatcher>();
            View.NextLevelClicked += OnNextLevelClicked;
            View.SetState(_payload.IsWon);
            if (_payload.IsWon)
            {
                _playerModel.CompleteLevel();
            }
        }

        private void OnNextLevelClicked()
        {
            _levelLoader.LoadNextLevel(_playerModel.CurrentLevel.LevelNumber)
                .Then(() => _uiManager.OpenView(RegisteredViews.StartScreen));
        }

        public override void Dispose()
        {
            View.NextLevelClicked -= OnNextLevelClicked;
        }
    }
}
using Framework.UI.Manager;
using Project.Scripts.Constants;
using Project.Scripts.GameControl.Loader;
using Project.Scripts.GamePlay.Models;
using Project.Scripts.GamePlay.UI.Result;

namespace Project.Scripts.GameControl.Watchers
{
    public class GameEndWatcher : IWatcher
    {
        private readonly IEnemyModel _enemyModel;
        private readonly ITownHallModel _townHallModel;
        private readonly IUIManager _uiManager;
        private readonly ILevelLoader _levelLoader;

        public GameEndWatcher(IEnemyModel enemyModel, 
            ITownHallModel townHallModel, 
            IUIManager uiManager,
            ILevelLoader levelLoader)
        {
            _enemyModel = enemyModel;
            _townHallModel = townHallModel;
            _uiManager = uiManager;
            _levelLoader = levelLoader;
        }

        public void Initialise()
        {
            _enemyModel.AllEnemiesDied += OnAllEnemiesDied;
            _townHallModel.Destroyed += OnTownHallDestroyed;
        }

        private void OnTownHallDestroyed()
        {
            _enemyModel.Clear();
            var payload = new ResultScreenPayload(false);
            _uiManager.OpenView(RegisteredViews.ResultScreen,payload);
            UnSubscribe();
        }

        private void OnAllEnemiesDied()
        {
            var payload = new ResultScreenPayload(true);
            _uiManager.OpenView(RegisteredViews.ResultScreen,payload);
        }

        private void UnSubscribe()
        {
            _enemyModel.AllEnemiesDied -= OnAllEnemiesDied;
            _townHallModel.Destroyed -= OnTownHallDestroyed;
        }
        
        public void Dispose()
        {
            UnSubscribe();
        }
    }
}
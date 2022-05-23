using Framework.UI.MVP.Views.Core;
using Project.Scripts.Configs;
using Project.Scripts.GamePlay.Enemy.Data;
using Project.Scripts.GamePlay.Models;

namespace Project.Scripts.GamePlay.UI.GameScreen.View
{
    public class GameScreenPresenter : Presenter<GameScreenView>
    {
        private readonly IEnemyModel _enemyModel;
        private readonly IConfig _config;
        private readonly ITownHallModel _townHallModel;
        private readonly IInGameEnergyModel _inGameEnergyModel;

        public GameScreenPresenter(
            GameScreenView view, 
            IEnemyModel enemyModel, 
            IConfig config,
            ITownHallModel townHallModel,
            IInGameEnergyModel inGameEnergyModel) : base(view)
        {
            _enemyModel = enemyModel;
            _config = config;
            _townHallModel = townHallModel;
            _inGameEnergyModel = inGameEnergyModel;
        }

        public override void Initialise()
        {
            _enemyModel.EnemyCreated += OnEnemyPlaced;
            _inGameEnergyModel.Count.BindAndInvoke(OnEnergyCountChanged);
            View.PlayerHealth.Initialise(_townHallModel.TownHallHealth);
            View.HeathBarContainer.SetConfig(_config.Get<ElementConfig>());
        }

        private void OnEnergyCountChanged(int count)
        {
            View.EnergyBarView.SetEnergyCount(count);
        }

        private void OnEnemyPlaced(IEnemyData enemy)
        {
            View.HeathBarContainer.AddBar(enemy);
        }

        public override void Dispose()
        {
            _enemyModel.EnemyCreated -= OnEnemyPlaced;
        }
    }
}
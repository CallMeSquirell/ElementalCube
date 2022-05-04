using Framework.ResourceManagement;
using Framework.UI.MVP.Views.Core;
using Project.Scripts.Framework.ResourceManagement.Game.GameScreen.Models;
using Project.Scripts.GameControl;
using Project.Scripts.GamePlay.Enemy.Data;

namespace Project.Scripts.Framework.ResourceManagement.Game.GameScreen
{
    public class GameScreenPresenter : Presenter<GameScreenView>
    {
        private readonly IEnemyModel _enemyModel;
        private readonly IConfig _config;

        public GameScreenPresenter(GameScreenView view, IEnemyModel enemyModel, IConfig config) : base(view)
        {
            _enemyModel = enemyModel;
            _config = config;
        }

        public override void Initialise()
        {
            _enemyModel.EnemyCreated += OnEnemyPlaced;
            View.HeathBarContainer.SetConfig(_config.Get<ElementConfig>());
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
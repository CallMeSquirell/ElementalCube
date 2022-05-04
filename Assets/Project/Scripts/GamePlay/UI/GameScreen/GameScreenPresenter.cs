using Framework.UI.MVP.Views.Core;
using Project.Scripts.Framework.ResourceManagement.Game.GameScreen.Models;
using Project.Scripts.GamePlay.Enemy.Data;

namespace Project.Scripts.Framework.ResourceManagement.Game.GameScreen
{
    public class GameScreenPresenter : Presenter<GameScreenView>
    {
        private readonly IEnemyModel _enemyModel;

        public GameScreenPresenter(GameScreenView view, IEnemyModel enemyModel) : base(view)
        {
            _enemyModel = enemyModel;
        }

        public override void Initialise()
        {
            _enemyModel.EnemyCreated += OnEnemyPlaced;
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
using Framework.UI.MVP.Views.Core;

namespace Project.Scripts.Framework.ResourceManagement.Game.GameScreen
{
    public class GameScreenView : ScreenBaseView
    {
        private EnemyHealthBarContainer _heathBarContainer;

        public EnemyHealthBarContainer HeathBarContainer => _heathBarContainer;
    }
}
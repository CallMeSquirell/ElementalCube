using Framework.UI.MVP.Views.Core;
using UnityEngine;

namespace Project.Scripts.Framework.ResourceManagement.Game.GameScreen
{
    public class GameScreenView : ScreenBaseView
    {
        [SerializeField] private EnemyHealthBarContainer _heathBarContainer;

        public EnemyHealthBarContainer HeathBarContainer => _heathBarContainer;
    }
}
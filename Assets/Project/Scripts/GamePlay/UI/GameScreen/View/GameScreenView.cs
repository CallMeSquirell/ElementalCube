using Framework.UI.MVP.Views.Core;
using Project.Scripts.GamePlay.UI.GameScreen.HealthBar;
using Project.Scripts.GamePlay.UI.GameScreen.HealthPointSystme;
using UnityEngine;

namespace Project.Scripts.GamePlay.UI.GameScreen.View
{
    public class GameScreenView : ScreenBaseView
    {
        [SerializeField] private EnemyHealthBarContainer _heathBarContainer;
        [SerializeField] private HealthPointWidget _healthPoint;
        [SerializeField] private EnergyBarView _energyBarView;

        public EnergyBarView EnergyBarView => _energyBarView;
        public EnemyHealthBarContainer HeathBarContainer => _heathBarContainer;
        public HealthPointWidget PlayerHealth => _healthPoint;
    }
}
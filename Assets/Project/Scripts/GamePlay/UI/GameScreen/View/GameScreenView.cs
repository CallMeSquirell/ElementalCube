using System;
using Framework.UI.MVP.Views.Core;
using Project.Scripts.GamePlay.UI.GameScreen.HealthBar;
using Project.Scripts.GamePlay.UI.GameScreen.HealthPointSystme;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts.GamePlay.UI.GameScreen.View
{
    public class GameScreenView : ScreenBaseView
    {
        public event Action SettingsButtonClicked;
        
        [SerializeField] private EnemyHealthBarContainer _heathBarContainer;
        [SerializeField] private HealthPointWidget _healthPoint;
        [SerializeField] private EnergyBarView _energyBarView;
        [SerializeField] private Button _settingsButton;

        public EnergyBarView EnergyBarView => _energyBarView;
        public EnemyHealthBarContainer HeathBarContainer => _heathBarContainer;
        public HealthPointWidget PlayerHealth => _healthPoint;

        protected override void Awake()
        {
            base.Awake();
            _settingsButton.onClick.AddListener(OnSettingsButtonClicked);
        }

        private void OnSettingsButtonClicked()
        {
            SettingsButtonClicked?.Invoke();
        }

        private void OnDestroy()
        {
            _settingsButton.onClick.RemoveListener(OnSettingsButtonClicked);
        }
    }
}
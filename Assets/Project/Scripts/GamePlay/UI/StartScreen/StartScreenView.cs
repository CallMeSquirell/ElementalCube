using System;
using System.Collections.Generic;
using Framework.UI.MVP.Views.Core;
using Framework.UI.Utils;
using Project.Scripts.Configs;
using Project.Scripts.GamePlay.LevelSystem;
using TMPro;
using UnityEngine;

namespace Project.Scripts.GamePlay.UI.StartScreen
{
    public class StartScreenView : ScreenBaseView
    {
        public event Action PlayClicked;
        [SerializeField] private ActionPanel _actionPanel;
        [SerializeField] private TextMeshProUGUI _levelNumber;
        [SerializeField] private EnemyPacksContainer _enemyPacksContainer;
        
        protected override void Start()
        {
            base.Start();
            _actionPanel.Clicked += OnActionPanelClicked;
        }
        private void OnActionPanelClicked()
        {
            PlayClicked?.Invoke();
        }
        
        private void OnDestroy()
        {
            _actionPanel.Clicked -= OnActionPanelClicked;
        }

        public void SetLevelNumber(int currentLevelLevelNumber)
        {
            _levelNumber.text = "Level " + currentLevelLevelNumber;
        }

        public void SetEnemyPreview(List<EnemyPack> currentLevelPacks)
        {
            _enemyPacksContainer.SetConfig(Config.Get<EnemyConfig>());
            _enemyPacksContainer.SetData(currentLevelPacks);
        }
    }
}
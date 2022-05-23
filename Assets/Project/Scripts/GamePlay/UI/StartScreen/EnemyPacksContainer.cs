using System.Collections.Generic;
using Project.Scripts.Configs;
using Project.Scripts.GamePlay.LevelSystem;
using UnityEngine;

namespace Project.Scripts.GamePlay.UI.StartScreen
{
    public class EnemyPacksContainer : MonoBehaviour
    {
        [SerializeField] private Transform _container;
        [SerializeField] private EnemyPreview _preview;

        private readonly List<EnemyPreview> _previews = new List<EnemyPreview>();
        private EnemyConfig _enemyConfig;

        public void SetConfig(EnemyConfig config)
        {
            _enemyConfig = config;
        }
        
        public void SetData(List<EnemyPack> currentLevelPacks)
        {
            Clear();
            foreach (var pack in currentLevelPacks)
            {
                if (pack.Count > 0)
                {
                    var preview = Instantiate(_preview, _container);
                    preview.SetImage(_enemyConfig.GetEnemyByType(pack.Type).Sprite, pack.Count);
                    _previews.Add(preview);
                }
            }
        }

        public void Clear()
        {
            foreach (var preview in _previews)
            {
                Destroy(preview.gameObject);
            }
        }

        private void OnDestroy()
        {
            Clear();
        }
    }
}
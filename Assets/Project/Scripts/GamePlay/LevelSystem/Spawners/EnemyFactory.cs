using Framework.ResourceManagement;
using Project.Scripts.GamePlay.Enemy.Configs;
using Project.Scripts.GamePlay.Enemy.Data;
using Project.Scripts.GamePlay.Enemy.Data.Stats;
using Project.Scripts.GamePlay.Enemy.Views;
using UnityEngine;
using Zenject;

namespace Project.Scripts.GamePlay.LevelSystem.Spawners
{
    public class EnemyFactory : IEnemyFactory
    {
        private readonly IInstantiator _instantiator;
        private readonly EnemyConfig _enemyConfig;

        public EnemyFactory(IInstantiator instantiator, IConfig config)
        {
            _instantiator = instantiator;
            _enemyConfig = config.Get<EnemyConfig>();
        }

        public EnemyView Create(Transform spawnPoint)
        {
            var enemy = _instantiator.InstantiatePrefabForComponent<EnemyView>(_enemyConfig.Definition, spawnPoint);
            return enemy;
        }
    }

    public interface IEnemyFactory
    {
        EnemyView Create(Transform spawnPoint);
    }
}
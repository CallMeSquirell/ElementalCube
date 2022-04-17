using System.Collections;
using System.Collections.Generic;
using Project.Scripts.Framework.MVP;
using Project.Scripts.Framework.ResourceManagement;
using Project.Scripts.GamePlay.Enemy.Configs;
using Project.Scripts.GamePlay.Enemy.Data;
using Project.Scripts.GamePlay.Enemy.Views;
using UnityEngine;
using Zenject;

namespace Project.Scripts.GamePlay.LevelSystem.Spawners
{
    public sealed class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private EnemySpawnerData _enemySpawnerData;
        [SerializeField] private Transform _spawnPoint;
        
        private int _currentSpawnIndex;
        private Coroutine _spawnCoroutine;
        private EnemyConfig _config;
        private IInstantiator _instantiator;
        
        private readonly Dictionary<IEnemyData, EnemyView> _spawnedEnemies = new Dictionary<IEnemyData, EnemyView>();

        private IEnemySpawnerData Data => _enemySpawnerData;

        [Inject]
        public void Construct(IInstantiator instantiator)
        {
            _instantiator = instantiator;
        }
        
        private void Awake()
        {
            _config = Config.Get<EnemyConfig>();
        }

        public void Play()
        {
            Stop();
            _currentSpawnIndex = 0;
            _spawnCoroutine = StartCoroutine(SpawnCoroutine());
        }
        
        public void Stop()
        {
            if (_spawnCoroutine != null)
            {
                StopCoroutine(_spawnCoroutine);
                _spawnCoroutine = null;
            }
        }

        private IEnumerator SpawnCoroutine()
        {
            var startDelay = Data.StartSpawnDelay;
            var waiter = new WaitForSeconds(Data.SpawnDeltaTime);
            var list = Data.SlimeList;

            if (startDelay > 0)
            {
                yield return new WaitForSeconds(startDelay);
            }

            while (_currentSpawnIndex < list.Count)
            {
                var enemy = list[_currentSpawnIndex];
                yield return waiter;
                Spawn(enemy);
                _currentSpawnIndex++;
            }
        }

        private void Spawn(IEnemyData data)
        {
            var enemy = _instantiator.InstantiatePrefabForComponent<EnemyView>(_config.Definition.Prefab, _spawnPoint);
            enemy.SetData(data);
            enemy.Attack(Data.Target);
            data.Died += OnEnemyDied;
            _spawnedEnemies.Add(data, enemy);
        }

        private void OnEnemyDied(IEnemyData enemyData)
        {
            enemyData.Died -= OnEnemyDied;
            _spawnedEnemies.Remove(enemyData);
        }
    }
}
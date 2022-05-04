using System.Collections;
using System.Collections.Generic;
using Framework.ResourceManagement;
using Project.Scripts.Framework.ResourceManagement.Game.GameScreen.Models;
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
        private EnemyConfig _enemyConfig;
        private IEnemyModel _enemyModel;
        private IConfig _config;
        private IInstantiator _instantiator;
        
        private IEnemySpawnerData Data => _enemySpawnerData;

        [Inject]
        public void Construct(IInstantiator instantiator, IConfig config, IEnemyModel enemyModel)
        {
            _enemyModel = enemyModel;
            _instantiator = instantiator;
            _config = config;
        }
        
        private void Awake()
        {
            _enemyConfig = _config.Get<EnemyConfig>();
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
            var enemy = _instantiator.InstantiatePrefabForComponent<EnemyView>(_enemyConfig.Definition, _spawnPoint);
            enemy.SetData(data);
            enemy.Attack(Data.Target);
            data.Died += OnEnemyDied;
            _enemyModel.Place(data);
        }

        private void OnEnemyDied(IEnemyData enemyData)
        {
            enemyData.Died -= OnEnemyDied;
            _enemyModel.Remove(enemyData);
        }
    }
}
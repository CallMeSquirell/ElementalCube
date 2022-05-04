using System.Collections;
using Project.Scripts.Framework.ResourceManagement.Game.GameScreen.Models;
using Project.Scripts.GamePlay.Enemy.Configs;
using Project.Scripts.GamePlay.Enemy.Data;
using Project.Scripts.GamePlay.Enemy.Data.Stats;
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
        private IEnemyFactory _enemyFactory;
     
        private IEnemySpawnerData Data => _enemySpawnerData;

        [Inject]
        public void Construct( IEnemyModel enemyModel, IEnemyFactory enemyFactory)
        {
            _enemyFactory = enemyFactory;
            _enemyModel = enemyModel;
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

        private void Spawn(IEnemyInfo info)
        {
            var enemy = _enemyFactory.Create(_spawnPoint);
            var data = new EnemyData(info, enemy.transform);
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
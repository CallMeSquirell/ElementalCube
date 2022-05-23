using System.Collections;
using Project.Scripts.Configs;
using Project.Scripts.GamePlay.Enemy;
using Project.Scripts.GamePlay.Enemy.Data;
using Project.Scripts.GamePlay.Enemy.Data.Stats;
using Project.Scripts.GamePlay.Models;
using UnityEngine;
using Zenject;

namespace Project.Scripts.GamePlay.LevelSystem.Spawners
{
    public sealed class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private EnemySpawnerData _enemySpawnerData;
        [SerializeField] private Transform _spawnPoint;
        
        private Coroutine _spawnCoroutine;
        private IEnemyModel _enemyModel;
        private IEnemyFactory _enemyFactory;
        private EnemyConfig _enemyConfig;
     
        private IEnemySpawnerData Data => _enemySpawnerData;

        [Inject]
        public void Construct(IEnemyModel enemyModel, 
            IEnemyFactory enemyFactory, 
            IConfig config)
        {
            _enemyFactory = enemyFactory;
            _enemyModel = enemyModel;
            _enemyConfig = config.Get<EnemyConfig>();
        }
        
        public void Play()
        {
            Stop();
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

            if (startDelay > 0)
            {
                yield return new WaitForSeconds(startDelay);
            }

            while (_enemyModel.TryGetNextEnemy(out EnemyType type))
            {
                Spawn(type);
                yield return waiter;
            }
            _spawnCoroutine = null;
        }

        private void Spawn(EnemyType type)
        { 
            var enemy = _enemyFactory.Create(_spawnPoint, type);
            var data = new EnemyData(_enemyConfig.GetEnemyByType(type), enemy.transform);
            enemy.SetData(data);
            enemy.Attack(Data.Target);
            _enemyModel.Place(data);
        }
    }
}
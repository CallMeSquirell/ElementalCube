using System;
using System.Collections.Generic;
using System.Linq;
using Project.Scripts.GamePlay.Enemy.Data;
using Project.Scripts.GamePlay.Enemy.Data.Stats;
using Project.Scripts.GamePlay.Health;
using Project.Scripts.GamePlay.LevelSystem.TownHalls;
using UnityEngine;

namespace Project.Scripts.GamePlay.LevelSystem.Spawners
{
    [Serializable]
    public class EnemySpawnerData : IEnemySpawnerData
    {
        [SerializeField] 
        private float _startDelay;
        
        [SerializeField] 
        private float _spawnDelay;
        
        [SerializeField] 
        private List<EnemyInfo> _enemies;
        
        [SerializeField] private TownHall _townHall;

        private IReadOnlyList<IEnemyData> _enemyDataList;

        public float StartSpawnDelay => _startDelay;

        public float SpawnDeltaTime => _spawnDelay;

        public IAttackTarget Target => _townHall;
        public IReadOnlyList<IEnemyData> SlimeList => _enemyDataList ?? (_enemyDataList = CreateEnemyData());
        
        private IReadOnlyList<IEnemyData> CreateEnemyData()
        {
            return _enemies.Select(info => new EnemyData(info)).ToList();
        }
    }
}
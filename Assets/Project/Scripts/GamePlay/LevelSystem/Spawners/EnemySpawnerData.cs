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
        
        public float StartSpawnDelay => _startDelay;

        public float SpawnDeltaTime => _spawnDelay;

        public IAttackTarget Target => _townHall;
        public IReadOnlyList<IEnemyInfo> SlimeList => _enemies;
        
    }
}
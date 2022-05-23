using System;
using System.Collections.Generic;
using Project.Scripts.GamePlay.Enemy;
using Project.Scripts.GamePlay.Enemy.Data;
using Project.Scripts.GamePlay.LevelSystem;
using Random = UnityEngine.Random;

namespace Project.Scripts.GamePlay.Models
{
    public class EnemyModel : IEnemyModel
    {
        public event Action AllEnemiesDied;
        public event Action<IEnemyData> EnemyCreated;

        private readonly List<IEnemyData> _placedEnemies = new List<IEnemyData>();
        private readonly List<EnemyType> _enemyToPlace = new List<EnemyType>();
        public IReadOnlyList<IEnemyData> PlacedEnemies => _placedEnemies;

        public void SetEnemyPack(List<EnemyPack> currentLevelPacks)
        {
            Clear();
            foreach (var pack in currentLevelPacks)
            {
                for (int i = 0; i < pack.Count; i++)
                {
                    _enemyToPlace.Add(pack.Type);
                }
            }
        }

        public void Clear()
        {
            foreach (var enemy in _placedEnemies)
            {
                enemy.Died -= OnEnemyDied;
                enemy.Kill();
            }

            _placedEnemies.Clear();
            _enemyToPlace.Clear();
        }

        public bool TryGetNextEnemy(out EnemyType type)
        {
            var count = _enemyToPlace.Count;
            if (count > 0)
            {
                type = _enemyToPlace[Random.Range(0, count)];
                _enemyToPlace.Remove(type);
                return true;
            }

            type = EnemyType.ElectroSlime;
            return false;
        }

        public void Place(IEnemyData cubeData)
        {
            _placedEnemies.Add(cubeData);
            cubeData.Died += OnEnemyDied;
            EnemyCreated?.Invoke(cubeData);
        }

        private void OnEnemyDied(IEnemyData cubeData)
        {
            cubeData.Died -= OnEnemyDied;
            _placedEnemies.Remove(cubeData);
            if (_enemyToPlace.Count == 0 && _placedEnemies.Count == 0)
            {
                AllEnemiesDied?.Invoke();
            }
        }
    }
}
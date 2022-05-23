using System;
using System.Collections.Generic;
using Project.Scripts.GamePlay.Enemy;
using Project.Scripts.GamePlay.Enemy.Data;
using Project.Scripts.GamePlay.LevelSystem;

namespace Project.Scripts.GamePlay.Models
{
    public interface IEnemyModel
    {
        event Action AllEnemiesDied;
        event Action<IEnemyData> EnemyCreated;
        IReadOnlyList<IEnemyData> PlacedEnemies { get; }
        bool TryGetNextEnemy(out EnemyType type);
        void Place(IEnemyData cubeData);
        void SetEnemyPack(List<EnemyPack> currentLevelPacks);
        void Clear();
    }
}
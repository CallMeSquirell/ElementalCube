using System.Collections.Generic;
using Project.Scripts.GamePlay.Enemy.Data;
using Project.Scripts.GamePlay.Health;

namespace Project.Scripts.GamePlay.LevelSystem.Spawners
{
    public interface IEnemySpawnerData
    {
        IReadOnlyList<IEnemyData> SlimeList { get; }
        float SpawnDeltaTime { get; }
        float StartSpawnDelay { get; }
        IAttackTarget Target { get; }
    }
}
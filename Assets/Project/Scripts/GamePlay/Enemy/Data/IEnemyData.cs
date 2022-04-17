using System;
using Project.Scripts.GamePlay.Enemy.Data.Stats;
using Project.Scripts.GamePlay.Health.Data;

namespace Project.Scripts.GamePlay.Enemy.Data
{
    public interface IEnemyData : IDisposable
    {
        event Action<IEnemyData> Died;
        IHealthData HealthData { get; }
        IEnemyInfo Stats { get; }
    }
}
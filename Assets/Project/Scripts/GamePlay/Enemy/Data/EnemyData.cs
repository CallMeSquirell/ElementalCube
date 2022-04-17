using System;
using Project.Scripts.GamePlay.Enemy.Data.Stats;
using Project.Scripts.GamePlay.Health;
using Project.Scripts.GamePlay.Health.Data;
using Project.Scripts.GamePlay.Health.Hits;

namespace Project.Scripts.GamePlay.Enemy.Data
{
    public class EnemyData : IEnemyData
    {
        public event Action<IEnemyData> Died;

        public IHealthData HealthData { get; }
        public IEnemyInfo Stats { get; }
        
        public EnemyData(IEnemyInfo stats)
        {
            Stats = stats;
            HealthData = new HealthData(Stats.MaxHealth);
            HealthData.LethalHitProcessed += OnLethalHitProcessed;
        }

        private void OnLethalHitProcessed(IHit hit)
        {
            Died?.Invoke(this);
        }

        public void Dispose()
        {
            HealthData.LethalHitProcessed -= OnLethalHitProcessed;
        }
    }
}
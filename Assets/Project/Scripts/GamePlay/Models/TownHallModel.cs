using System;
using Project.Scripts.Configs;
using Project.Scripts.GamePlay.Health.Data;
using Project.Scripts.GamePlay.Health.Hits;

namespace Project.Scripts.GamePlay.Models
{
    public class TownHallModel : ITownHallModel
    {
        public event Action Destroyed;
        public IHealthData TownHallHealth => _healthData;

        private HealthData _healthData;
        
        public TownHallModel(IConfig config)
        {
            _healthData = new HealthData(config.Get<PlayerConfig>().HealthCount);
            _healthData.LethalHitProcessed += OnLethalHitProcessed;
        }

        private void OnLethalHitProcessed(IHit hit)
        {
            Destroyed?.Invoke();
        }

        public void Reset()
        {
            _healthData.Reset();
        }
    }
}
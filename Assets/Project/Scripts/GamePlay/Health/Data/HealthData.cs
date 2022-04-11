using System;
using Project.Scripts.GamePlay.Health.Hits;

namespace Project.Scripts.GamePlay.Health.Data
{
    public class HealthData : IHealthData
    {
        public event Action<IHit> HitProcessed;
        public event Action<IHit> LethalHitProcessed;

        public int CurrentHealthCount { get; private set; }
        public int MaxHealthCount { get; private set; }

        private IHit _lastHit;

        public HealthData(int maxHealthCount, int currentHealthCount)
        {
            MaxHealthCount = maxHealthCount;
            CurrentHealthCount = currentHealthCount;
        }

        public HealthData(int maxHealthCount)
        {
            MaxHealthCount = maxHealthCount;
            CurrentHealthCount = MaxHealthCount;
        }

        public void AddHit(IHit value, bool apply = false)
        {
            ApplyDamage();
            GetDamage(value);
            
            _lastHit = value;
            
            if (apply)
            {
                ApplyDamage();
            }
        }

        public void ApplyDamage()
        {
            if (_lastHit != null)
            {
                if (CurrentHealthCount == 0)
                {
                    LethalHitProcessed?.Invoke(_lastHit);
                }
                else
                {
                    HitProcessed?.Invoke(_lastHit);
                }
                _lastHit = null;
            }
        }

        private void GetDamage(IHit hit)
        {
            CurrentHealthCount -= _lastHit.Damage;
        }
    }
}
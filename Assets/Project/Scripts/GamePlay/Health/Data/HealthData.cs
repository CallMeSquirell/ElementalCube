using System;
using Project.Scripts.GamePlay.Health.Hits;
using UnityEngine;

namespace Project.Scripts.GamePlay.Health.Data
{
    public class HealthData : IHealthData
    {
        public event Action<IHit> HitProcessed;
        public event Action<IHit> LethalHitProcessed;

        public int CurrentHealthCount { get; private set; }
        public int MaxHealthCount { get; private set; }

        public double HealthPercent => Math.Round(CurrentHealthCount * 1.0d / MaxHealthCount, 4);

        private IHit _lastHit;
        
        public HealthData(int maxHealthCount)
        {
            MaxHealthCount = maxHealthCount;
            Reset();
        }

        public void Reset()
        {
            CurrentHealthCount = MaxHealthCount;
        }

        public void AddHit(IHit value, bool apply = false)
        {
            ApplyDamage();

            _lastHit = value;
            GetDamage();

            if (apply)
            {
                ApplyDamage();
            }
        }

        public void ApplyDamage()
        {
            if (_lastHit != null)
            {
                HitProcessed?.Invoke(_lastHit);
                if (CurrentHealthCount == 0)
                {
                    LethalHitProcessed?.Invoke(_lastHit);
                }

                _lastHit = null;
            }
        }

        private void GetDamage()
        {
            CurrentHealthCount = Mathf.Clamp(CurrentHealthCount - _lastHit.Damage, 0, MaxHealthCount);
        }
    }
}
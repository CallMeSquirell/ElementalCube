using System;
using Project.Scripts.GamePlay.Health.Hits;

namespace Project.Scripts.GamePlay.Health.Data
{
    public interface IHealthData
    {
        event Action<IHit> HitProcessed;
        event Action<IHit> LethalHitProcessed;
        int CurrentHealthCount { get; }
        int MaxHealthCount { get; }
        void AddHit(IHit value, bool apply = false);
        void ApplyDamage();
    }
}
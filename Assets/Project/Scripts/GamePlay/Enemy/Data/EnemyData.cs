using System;
using Framework.BindableProperties;
using Project.Scripts.GamePlay.Cube.Data.Faces;
using Project.Scripts.GamePlay.Enemy.Data.Stats;
using Project.Scripts.GamePlay.Health.Data;
using Project.Scripts.GamePlay.Health.Hits;
using UnityEngine;

namespace Project.Scripts.GamePlay.Enemy.Data
{
    public class EnemyData : IEnemyData
    {
        public event Action<IEnemyData> Died;

        private readonly BindableProperty<Element> _currentElement = new BindableProperty<Element>();
        public IBindableProperty<Element> CurrentElement => _currentElement;
        public IHealthData HealthData { get; }
        public IEnemyInfo Stats { get; }
        public Transform Transform { get; }

        public bool HasScore { get; private set; } = false; 

        public EnemyData(IEnemyInfo stats, Transform transform)
        {
            Stats = stats;
            Transform = transform;
            ApplyElement(stats.Element);
            HealthData = new HealthData(Stats.MaxHealth);
            HealthData.LethalHitProcessed += OnLethalHitProcessed;
        }
        
        public void ApplyElement(Element element)
        {
            _currentElement.Value = element;
        }
        
        private void OnLethalHitProcessed(IHit hit)
        {
            Died?.Invoke(this);
        }

        public void Kill(bool withScore = false)
        {
            HasScore = withScore;
            Died?.Invoke(this);
        }

        public void Dispose()
        {
            HealthData.LethalHitProcessed -= OnLethalHitProcessed;
        }
    }
}
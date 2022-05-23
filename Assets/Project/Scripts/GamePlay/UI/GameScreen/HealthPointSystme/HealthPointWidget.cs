using System.Collections.Generic;
using Project.Scripts.GamePlay.Health.Data;
using Project.Scripts.GamePlay.Health.Hits;
using UnityEngine;

namespace Project.Scripts.GamePlay.UI.GameScreen.HealthPointSystme
{
    public class HealthPointWidget : MonoBehaviour
    {
        [SerializeField] private HealthPoint _heartPrefab;
        [SerializeField] private Transform _container;

        private readonly List<HealthPoint> _spawnedHearts = new List<HealthPoint>();
        private IHealthData _data;
        
        public void Initialise(IHealthData data)
        {
            Clear();
            _data = data;
            for (int i = 0; i <  data.MaxHealthCount; i++)
            {
                var image = Instantiate(_heartPrefab, _container);
                _spawnedHearts.Add(image);
            }
            UpdateCounter();
            data.HitProcessed += OnHitProcessed;
        }

        private void OnHitProcessed(IHit obj)
        {
            UpdateCounter();
        }

        private void UpdateCounter()
        {
            int i = 0;
            for (; i < _data.CurrentHealthCount; i++)
            {
                _spawnedHearts[i].SetState(true);
            }

            for (; i < _data.MaxHealthCount; i++)
            {
                _spawnedHearts[i].SetState(false);
            }
        }
        
        private void Clear()
        {
            if (_data!= null)
            {
                _data.HitProcessed -= OnHitProcessed;
            }
            foreach (var heart in _spawnedHearts)
            {
                Destroy(heart.gameObject);
            }
            _spawnedHearts.Clear();
        }

        private void OnDestroy()
        {
            Clear();
        }
    }
}
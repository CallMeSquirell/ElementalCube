using System;
using Project.Scripts.GamePlay.Health.Data;
using UnityEngine;

namespace Project.Scripts.GamePlay.LevelSystem.TownHalls
{
    [Serializable]
    public class TownHallData : ITownHallData
    {
        [SerializeField] private int _healthCount;
        public IHealthData HealthData => _healthData ?? (_healthData = new HealthData(_healthCount));

        private IHealthData _healthData;
    }
}
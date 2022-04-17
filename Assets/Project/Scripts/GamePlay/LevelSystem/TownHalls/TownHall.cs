using Project.Scripts.GamePlay.Health;
using Project.Scripts.GamePlay.Health.Data;
using UnityEngine;

namespace Project.Scripts.GamePlay.LevelSystem.TownHalls
{
    public class TownHall : MonoBehaviour, IAttackTarget
    {
        [SerializeField] private TownHallData _data;
        
        private Transform _transform;
        public Vector3 Position => _transform.position;

        public IHealthData HealthData => Data.HealthData;

        public ITownHallData Data => _data;

        private void Awake()
        {
            _transform = transform;
        }
    }
}
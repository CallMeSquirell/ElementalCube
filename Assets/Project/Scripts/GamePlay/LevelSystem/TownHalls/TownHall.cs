using Project.Scripts.GamePlay.Health;
using Project.Scripts.GamePlay.Health.Data;
using Project.Scripts.GamePlay.Models;
using UnityEngine;
using Zenject;

namespace Project.Scripts.GamePlay.LevelSystem.TownHalls
{
    public class TownHall : MonoBehaviour, IAttackTarget
    {
    
        private Transform _transform;
        private ITownHallModel _townHallModel;
        public Vector3 Position => _transform.position;

        public IHealthData HealthData => _townHallModel.TownHallHealth;
        
        [Inject]
        public void Construct(ITownHallModel townHallModel)
        {
            _townHallModel = townHallModel;
        }
        
        private void Awake()
        {
            _transform = transform;
        }
    }
}
using Project.Scripts.GamePlay.Enemy.Data;
using UnityEngine;

namespace Project.Scripts.Framework.ResourceManagement.Game.GameScreen
{
    public class EnemyHealthBarContainer : MonoBehaviour
    {
        [SerializeField] private HealthBar _prefab;
        
        private HealthBarPool _healthBarPool = new HealthBarPool();

        private void Awake()
        {
            _healthBarPool.Initialise(_prefab, transform);
        }

        public void AddBar(IEnemyData enemy)
        {
            var healthBar = _healthBarPool.Get();
            healthBar.SetData(enemy);
        }
    }
}
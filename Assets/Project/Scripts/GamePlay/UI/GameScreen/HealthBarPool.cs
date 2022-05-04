using Framework.Pool;
using UnityEngine;

namespace Project.Scripts.Framework.ResourceManagement.Game.GameScreen
{
    public class HealthBarPool : AbstractPool<HealthBar>
    {
        private HealthBar _prefab;
        private Transform _transform;

        public void Initialise(HealthBar healthBar, Transform defaultParent = null)
        {
            _prefab = healthBar;
            _transform = defaultParent;
        }
        
        protected override HealthBar CreateItem()
        {
            return Object.Instantiate(_prefab, _transform);
        }
        
        
    }
}
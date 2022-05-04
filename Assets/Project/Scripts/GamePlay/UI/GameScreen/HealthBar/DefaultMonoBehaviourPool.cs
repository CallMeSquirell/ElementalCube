using Framework.Pool;
using UnityEngine;

namespace Project.Scripts.Framework.ResourceManagement.Game.GameScreen
{
    public class DefaultMonoBehaviourPool<T> : AbstractPool<T> where T : ObjectPoolItem
    {
        private T _prefab;
        private Transform _transform;

        public void Initialise(T healthBar, Transform defaultParent = null)
        {
            _prefab = healthBar;
            _transform = defaultParent;
        }
        
        protected override T CreateItem()
        {
            return Object.Instantiate(_prefab, _transform);
        }
    }
}
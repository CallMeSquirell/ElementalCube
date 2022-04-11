using Project.Scripts.Framework.Pool;
using Project.Scripts.GamePlay.Cube.Data.Element;
using Zenject;

namespace Project.Scripts.GamePlay.Health.Hits.Pool
{
    public class HitPool : AbstractPool<Hit>, IHitPool
    {
        private IInstantiator _instantiator;

        public HitPool(IInstantiator instantiator)
        {
            _instantiator = instantiator;
        }
        
        public IHit Get(int damage, IElementData element)
        {
            var hit = base.Get();
            hit.Damage = damage;
            hit.Element = element;
            return hit;
        }

        protected override Hit CreateItem()
        {
            return _instantiator.Instantiate<Hit>();
        }
    }
}
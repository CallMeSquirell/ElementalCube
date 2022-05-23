using Framework.Pool;
using Project.Scripts.GamePlay.Cube.Data.Elements;
using Project.Scripts.GamePlay.Cube.Data.Faces;
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
        
        public IHit Get(int damage, Element element)
        {
            var hit = base.Get();
            hit.Damage = damage;
            hit.Element = element;
            return hit;
        }

        protected override Hit CreateItem()
        {
            return new Hit();
        }
    }
}
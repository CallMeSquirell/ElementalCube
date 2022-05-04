using Project.Scripts.GamePlay.Cube.Data.Elements;
using Project.Scripts.GamePlay.Cube.Data.Stats;
using Project.Scripts.GamePlay.Enemy.Data;
using Project.Scripts.GamePlay.Health.Hits.Pool;

namespace Project.Scripts.GamePlay.Cube.Data.Faces.Impl
{
    public class ElementalFace : IFaceBonusData
    {
        private readonly IHitPool _hitPool;
        protected IElement Element { get; }

        public ElementalFace(IElement element, IHitPool hitPool)
        {
            _hitPool = hitPool;
            Element = element;
        }

        public virtual void Clear()
        {
          
        }

        public void Process(IEnemyData data, ICubeInfo info)
        {
            var enemyElement = data.CurrentElement;
            var damage = Element.ApplyExtraDamage(enemyElement.Value, info.Damage, out var resultElement);
            data.HealthData.AddHit(_hitPool.Get(resultElement, damage ? Element.Element : Faces.Element.Empty), true);
        }
    }
}
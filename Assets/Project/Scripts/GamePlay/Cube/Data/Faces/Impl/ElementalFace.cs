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
            var currentEnemyElement = data.CurrentElement;
            var critDamage = Element.ApplyExtraDamage(currentEnemyElement.Value, info.Damage, out var resultElement);
            Element element;
            if (critDamage)
            {
                data.ApplyElement(Faces.Element.Empty);
                element = Element.Element;
            }
            else
            {
                data.ApplyElement(Element.Element);
                element = Faces.Element.Empty;
            }
            
            AddHit(data, resultElement, element);
        }

        private void AddHit(IEnemyData data, int resultElement, Element element)
        {
            var hit = _hitPool.Get(resultElement, element);
            data.HealthData.AddHit(hit, true);
        }
    }
}
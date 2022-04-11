using Project.Scripts.Framework.Pool;
using Project.Scripts.GamePlay.Cube.Data.Element;

namespace Project.Scripts.GamePlay.Health.Hits
{
    public class Hit : PoolItem , IHit
    {
        public int Damage { get; set; }
        public IElementData Element { get; set; }

        public Hit(int damage, IElementData element)
        {
            Damage = damage;
            Element = element;
        }
    }
}
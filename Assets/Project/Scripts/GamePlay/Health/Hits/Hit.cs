using Framework.Pool;
using Project.Scripts.GamePlay.Cube.Data.Elements;
using Project.Scripts.GamePlay.Cube.Data.Faces;

namespace Project.Scripts.GamePlay.Health.Hits
{
    public class Hit : PoolItem , IHit
    {
        public int Damage { get; set; }
        public Element Element { get; set; }

        public Hit(){}
        public Hit(int damage, Element element)
        {
            Damage = damage;
            Element = element;
        }
    }
}
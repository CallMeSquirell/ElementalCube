using Project.Scripts.GamePlay.Cube.Data.Elements;
using Project.Scripts.GamePlay.Cube.Data.Faces;

namespace Project.Scripts.GamePlay.Health.Hits.Pool
{
    public interface IHitPool
    {
        IHit Get(int damage, Element element = Element.Empty);
    }
}
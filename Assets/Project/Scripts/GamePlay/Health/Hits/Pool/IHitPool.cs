using Project.Scripts.GamePlay.Cube.Data.Element;

namespace Project.Scripts.GamePlay.Health.Hits.Pool
{
    public interface IHitPool
    {
        IHit Get(int damage, IElementData element = null);
    }
}
using Project.Scripts.Framework.Pool;
using Project.Scripts.GamePlay.Cube.Data.Element;

namespace Project.Scripts.GamePlay.Health.Hits
{
    public interface IHit : IPoolItem
    {
        int Damage { get; }
        IElementData Element { get; }
    }
}
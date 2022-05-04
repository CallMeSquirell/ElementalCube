using Framework.Pool;
using Project.Scripts.GamePlay.Cube.Data.Elements;
using Project.Scripts.GamePlay.Cube.Data.Faces;

namespace Project.Scripts.GamePlay.Health.Hits
{
    public interface IHit : IPoolItem
    {
        int Damage { get; }
        Element Element { get; }
    }
}
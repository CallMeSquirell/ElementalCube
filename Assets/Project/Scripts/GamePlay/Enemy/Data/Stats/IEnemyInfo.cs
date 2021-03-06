using Project.Scripts.GamePlay.Cube.Data.Faces;

namespace Project.Scripts.GamePlay.Enemy.Data.Stats
{
    public interface IEnemyInfo
    {
        int MaxHealth { get; }
        float Speed { get; }
        Element Element { get; }
    }
}
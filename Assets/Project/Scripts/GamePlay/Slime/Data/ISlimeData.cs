using Project.Scripts.GamePlay.Health.Data;
using Project.Scripts.GamePlay.Slime.Data.Stats;

namespace Project.Scripts.GamePlay.Slime.Data
{
    public interface ISlimeData
    {
        IHealthData HealthData { get; }
        ISlimeStats Stats { get; }
    }
}
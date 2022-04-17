using Project.Scripts.GamePlay.Health.Data;

namespace Project.Scripts.GamePlay.LevelSystem.TownHalls
{
    public interface ITownHallData
    {
        IHealthData HealthData { get; }
    }
}
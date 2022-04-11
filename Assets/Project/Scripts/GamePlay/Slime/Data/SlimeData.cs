using Project.Scripts.GamePlay.Health.Data;
using Project.Scripts.GamePlay.Slime.Data.Stats;

namespace Project.Scripts.GamePlay.Slime.Data
{
    public class SlimeData : ISlimeData
    {
        public IHealthData HealthData { get; }
        public ISlimeStats Stats { get; }

        public SlimeData(ISlimeStats stats)
        {
            Stats = stats;
            HealthData = new HealthData(Stats.MaxHealth);
        }
    }
}
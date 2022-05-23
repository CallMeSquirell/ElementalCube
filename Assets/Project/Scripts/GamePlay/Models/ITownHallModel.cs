using System;
using Project.Scripts.GamePlay.Health.Data;

namespace Project.Scripts.GamePlay.Models
{
    public interface ITownHallModel
    {
        event Action Destroyed;
        IHealthData TownHallHealth { get; }
        void Reset();
    }
}
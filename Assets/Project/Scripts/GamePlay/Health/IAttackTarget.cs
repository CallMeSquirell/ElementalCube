using Project.Scripts.GamePlay.Health.Data;
using UnityEngine;

namespace Project.Scripts.GamePlay.Health
{
    public interface IAttackTarget
    {
        IHealthData HealthData { get; }
        Vector3 Position { get; }
    }
}
using System;
using Framework.BindableProperties;
using Project.Scripts.GamePlay.Cube.Data.Faces;
using Project.Scripts.GamePlay.Enemy.Data.Stats;
using Project.Scripts.GamePlay.Health.Data;
using UnityEngine;

namespace Project.Scripts.GamePlay.Enemy.Data
{
    public interface IEnemyData : IDisposable
    {
        event Action<IEnemyData> Died;
        IBindableProperty<Element> CurrentElement { get; }
        bool HasScore { get;}
        IHealthData HealthData { get; }
        IEnemyInfo Stats { get; }
        Transform Transform { get; }
        void ApplyElement(Element element);
        void Kill(bool withScore = false);
    }
}
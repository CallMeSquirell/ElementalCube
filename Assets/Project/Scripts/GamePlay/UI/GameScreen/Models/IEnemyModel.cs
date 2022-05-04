using System;
using System.Collections.Generic;
using Project.Scripts.GamePlay.Enemy.Data;

namespace Project.Scripts.Framework.ResourceManagement.Game.GameScreen.Models
{
    public interface IEnemyModel
    {
        event Action<IEnemyData> EnemyCreated;
        event Action<IEnemyData> EnemyRemoved;
        IReadOnlyList<IEnemyData> PlacedCubes { get; }
        void Place(IEnemyData cubeData);
        void Remove(IEnemyData cubeData);
    }
}
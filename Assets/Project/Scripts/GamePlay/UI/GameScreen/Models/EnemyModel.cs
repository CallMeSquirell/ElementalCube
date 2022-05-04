using System;
using System.Collections.Generic;
using Project.Scripts.GamePlay.Enemy.Data;

namespace Project.Scripts.Framework.ResourceManagement.Game.GameScreen.Models
{
    public class EnemyModel : IEnemyModel
    {
        public event Action<IEnemyData> EnemyCreated;
        public event Action<IEnemyData> EnemyRemoved;

        public IReadOnlyList<IEnemyData> PlacedCubes => _placedCubes;
        private readonly List<IEnemyData> _placedCubes = new List<IEnemyData>(); 

        public void Place(IEnemyData cubeData)
        {
            _placedCubes.Add(cubeData);
            EnemyCreated?.Invoke(cubeData);
        }

        public void Remove(IEnemyData cubeData)
        {
            _placedCubes.Remove(cubeData);
            EnemyRemoved?.Invoke(cubeData);
        }
    }
}
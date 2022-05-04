using System;
using System.Collections.Generic;
using Project.Scripts.GamePlay.Cube.Data;

namespace Project.Scripts.GamePlay.Models
{
    public class PlacedCubesModel : IPlacedCubeModel
    {
        public event Action<ICubeData> CubePlaced;
        public event Action<ICubeData> CubeRemoved;

        public IReadOnlyList<ICubeData> PlacedCubes => _placedCubes;
        private readonly List<ICubeData> _placedCubes = new List<ICubeData>(); 

        public void Place(ICubeData cubeData)
        {
            _placedCubes.Add(cubeData);
            CubePlaced?.Invoke(cubeData);
        }

        public void Remove(ICubeData cubeData)
        {
            _placedCubes.Remove(cubeData);
            CubeRemoved?.Invoke(cubeData);
        }
    }
}
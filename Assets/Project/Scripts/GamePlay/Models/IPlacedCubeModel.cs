using System;
using System.Collections.Generic;
using Project.Scripts.GamePlay.Cube.Data;

namespace Project.Scripts.GamePlay.Models
{
    public interface IPlacedCubeModel
    {
        event Action<ICubeData> CubePlaced;
        event Action<ICubeData> CubeRemoved;
        IReadOnlyList<ICubeData> PlacedCubes { get; }
        void Place(ICubeData cubeData);
        void Remove(ICubeData cubeData);
    }
}
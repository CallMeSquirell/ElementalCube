using System;
using System.Collections.Generic;
using Project.Scripts.GamePlay.Cube.Data.Face;
using Project.Scripts.GamePlay.Cube.Data.Faces;

namespace Project.Scripts.GamePlay.Cube.Data.Stats
{
    public interface ICubeInfo
    {
        int Damage { get; }
        int ShotsPerSecond { get; }
        float ShootRange { get; }

        IReadOnlyList<FaceType> Faces { get; }
    }
}
using System;
using System.Collections.Generic;

namespace Project.Scripts.GamePlay.Cube.Data.Stats
{
    public interface ICubeInfo
    {
        int Damage { get; }
        int ShotsPerSecond { get; }
        float ShootRange { get; }

        IReadOnlyList<Type> Faces { get; }
    }
}
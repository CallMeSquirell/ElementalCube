using System.Collections.Generic;
using Project.Scripts.GamePlay.Cube.Data;
using Project.Scripts.GamePlay.Cube.Data.Stats;

namespace Project.Scripts.GameControl.Models
{
    public interface ICubeSetModel
    {
        IReadOnlyList<ICubeInfo> CurrentCubeSet { get; }
        IReadOnlyList<ICubeInfo> AvailableCubeData { get; }
        void RefreshAvailableCubeDataList();
        void Retain(ICubeInfo data);
    }
}
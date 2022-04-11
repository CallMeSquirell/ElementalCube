using System.Collections.Generic;
using Project.Scripts.GamePlay.Cube.Data;
using Project.Scripts.GamePlay.Cube.Data.Stats;

namespace Project.Scripts.GameControl.Models
{
    public interface ICubeSetModel
    {
        IReadOnlyList<CubeStats> CurrentCubeSet { get; }
        void RefreshAvailableCubeDataList();
    }
}
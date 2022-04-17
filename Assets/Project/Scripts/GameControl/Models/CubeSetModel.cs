using System.Collections.Generic;
using Project.Scripts.Framework.ResourceManagement;
using Project.Scripts.GamePlay.Cube.Configs;
using Project.Scripts.GamePlay.Cube.Data;
using Project.Scripts.GamePlay.Cube.Data.Stats;

namespace Project.Scripts.GameControl.Models
{
    public class CubeSetModel : ICubeSetModel
    {
        private IReadOnlyList<CubeInfo> _currentCubeSet;
        public List<CubeInfo> AvailableCubeData { private set; get; }

        public IReadOnlyList<CubeInfo> CurrentCubeSet
        {
            get => _currentCubeSet;
            private set
            {
                _currentCubeSet = value;
                RefreshAvailableCubeDataList();
            }
        }

        public CubeSetModel()
        {
            CurrentCubeSet = Config.Get<CubeConfig>().CubeSet;
        }

        public void RefreshAvailableCubeDataList()
        {
            AvailableCubeData = new List<CubeInfo>(CurrentCubeSet);
        }
    }
}
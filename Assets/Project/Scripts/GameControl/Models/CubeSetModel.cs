using System.Collections.Generic;
using Project.Scripts.Framework.ResourceManagement;
using Project.Scripts.GamePlay.Cube.Configs;
using Project.Scripts.GamePlay.Cube.Data;
using Project.Scripts.GamePlay.Cube.Data.Stats;

namespace Project.Scripts.GameControl.Models
{
    public class CubeSetModel : ICubeSetModel
    {
        private IReadOnlyList<CubeStats> _currentCubeSet;
        public List<CubeStats> AvailableCubeData { private set; get; }

        public IReadOnlyList<CubeStats> CurrentCubeSet
        {
            get => _currentCubeSet;
            private set
            {
                _currentCubeSet = value;
                RefreshAvailableCubeDataList();
            }
        }

        public CubeSetModel(IConfig config)
        {
            CurrentCubeSet = config.Get<CubeConfig>().CubeSet;
        }

        public void RefreshAvailableCubeDataList()
        {
            AvailableCubeData = new List<CubeStats>(CurrentCubeSet);
        }
    }
}
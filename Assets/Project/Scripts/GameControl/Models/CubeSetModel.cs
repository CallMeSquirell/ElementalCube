using System.Collections.Generic;
using System.Linq;
using Framework.ResourceManagement;
using Project.Scripts.Configs;
using Project.Scripts.GamePlay.Cube.Data.Stats;
using Zenject;

namespace Project.Scripts.GameControl.Models
{
    public class CubeSetModel : ICubeSetModel
    {
        private IReadOnlyList<ICubeInfo> _currentCubeSet;
        public IReadOnlyList<ICubeInfo> AvailableCubeData => _availableCubeData;

        private List<ICubeInfo> _availableCubeData;

        public IReadOnlyList<ICubeInfo> CurrentCubeSet
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
            CurrentCubeSet = config.Get<CubeSetConfig>().CubeSet;
        }

        public void Release(ICubeInfo cubeInfo)
        {
            if (_currentCubeSet.Contains(cubeInfo))
            {
                _availableCubeData.Add(cubeInfo);
            }
        }

        public void Retain(ICubeInfo cubeInfo)
        {
            _availableCubeData.Remove(cubeInfo);
        }

        public void RefreshAvailableCubeDataList()
        {
            _availableCubeData = new List<ICubeInfo>(CurrentCubeSet);
        }
    }
}
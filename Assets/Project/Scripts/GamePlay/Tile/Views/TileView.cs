using Framework.Extensions;
using Framework.MVVM;
using Project.Scripts.Configs;
using Project.Scripts.GamePlay.Cube.Data;
using Project.Scripts.GamePlay.Cube.Views;
using Project.Scripts.GamePlay.Tile.Data;
using Project.Scripts.GamePlay.UI.Input.System;
using UnityEngine;

namespace Project.Scripts.GamePlay.Tile.Views
{
    public class TileView : BaseView<ITileData>, ITouchable
    {
        [SerializeField] private Transform _cubeContainer;

        private CubeView _cubeView;
        private CubeSetConfig _cubeSetConfig;

        private void Awake()
        {
            _cubeSetConfig = Config.Get<CubeSetConfig>();
            SetData(new TileData(null));
        }

        protected override void Initialize()
        {
            Data.PlacedCube.BindAndInvoke(OnSelectedCubeUpdated);
        }
        
        private void OnSelectedCubeUpdated(ICubeData cubeData)
        {
            Clear();
            if (cubeData != null)
            {
                _cubeView = Instantiator.InstantiatePrefabForComponent<CubeView>(_cubeSetConfig.CubeView,
                    _cubeContainer);
                _cubeView.SetData(cubeData);
            }
        }

        private void Clear()
        {
            if (_cubeView.NonNull())
            {
                Destroy(_cubeView.gameObject);
                _cubeView = null;
            }
        }

        protected override void UnBind()
        {
            Data.PlacedCube.UnBind(OnSelectedCubeUpdated);
        }
    }
}
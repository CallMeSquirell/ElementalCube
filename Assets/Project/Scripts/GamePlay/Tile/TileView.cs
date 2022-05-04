using Framework.Extensions;
using Framework.MVVM;
using Framework.ResourceManagement;
using Project.Scripts.Framework.ResourceManagement;
using Project.Scripts.GamePlay.Cube.Configs;
using Project.Scripts.GamePlay.Cube.Data;
using Project.Scripts.GamePlay.Cube.Views;
using Project.Scripts.Input.Interfaces;
using UnityEngine;

namespace Project.Scripts.GamePlay.Tile
{
    public class TileView : BaseView<ITileData>, ITouchable
    {
        [SerializeField] private Transform _cubeContainer;

        private CubeView _cubeView;
        private CubeConfig _cubeConfig;

        private void Awake()
        {
            _cubeConfig = Config.Get<CubeConfig>();
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
                _cubeView = Instantiator.InstantiatePrefabForComponent<CubeView>(_cubeConfig.CubeView,
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
using Project.Scripts.Framework.Extensions;
using Project.Scripts.GameControl.Models;
using Project.Scripts.GamePlay.Cube.Data.Factory;
using Project.Scripts.GamePlay.Cube.Factory;
using Project.Scripts.GamePlay.Cube.Views;
using Project.Scripts.Input.Interfaces;
using UnityEngine;
using Zenject;

namespace Project.Scripts.GamePlay.Tile
{
    public class TileView : MonoBehaviour, IClickable, ITouchStarted, ITouchEnded
    {
        [SerializeField] private Transform _cubeContainer;
        
        private ICubeFactory _factory;
        private CubeView _placedCubeShooter;
        private ICubeDataFactory _dataFactory;
        private IPlaceModel _placeModel;

        [Inject]
        private void Initialize(IPlaceModel placeModel, 
            ICubeFactory cubeFactory, ICubeDataFactory dataFactory)
        {
            _dataFactory = dataFactory;
            _placeModel = placeModel;
            _factory = cubeFactory;
        }
        
        public void OnClicked()
        {
            if (!_placedCubeShooter.NonNull() && _placeModel.SelectedCube != null)
            {
                var cubeData = _dataFactory.Create(_placeModel.SelectedCube);
                _placedCubeShooter = _factory.Create(_cubeContainer);
                _placedCubeShooter.SetData(cubeData);
            }
        }

        public void OnTouchStarted()
        {
        }

        public void OnTouchEnded()
        {
            
        }
    }
}
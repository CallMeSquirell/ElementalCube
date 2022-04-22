using Project.Scripts.Framework.UI.Manager;
using Project.Scripts.GameControl.Models;
using Project.Scripts.GamePlay.Cube.Data.Faces.Provider;
using Project.Scripts.GamePlay.Tile;
using Project.Scripts.Input.Interfaces;

namespace Project.Scripts.Input.Processorors.Impl
{
    public class TileInputProcessor : IInputProcessor
    {
        private IPlaceModel _placeModel;
        private readonly IUIManager _uiManager;
        private IFaceDataProvider _faceDataProvider;

        public TileInputProcessor(
            IPlaceModel placeModel, 
            IUIManager uiManager)
        {
            _placeModel = placeModel;
            _uiManager = uiManager;
        }

        public void Click(ITouchable target)
        {
            if (target is TileView tile && tile.Data.PlacedCube == null)
            {
                _uiManager.OpenView();
            }
            
            var cubeToPlace = _placeModel.SelectedCube;
            if (cubeToPlace != null && )
            {
                tile.Data.PlaceCube(cubeToPlace);
            }
        }

        public void TouchStarted(ITouchable target)
        {
            
        }

        public void TouchEnded(ITouchable target)
        {
            
        }
    }
}
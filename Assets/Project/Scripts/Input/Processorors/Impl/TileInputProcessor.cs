using Project.Scripts.GameControl.Models;
using Project.Scripts.GamePlay.Cube.Data.Faces.Provider;
using Project.Scripts.GamePlay.Tile;
using Project.Scripts.Input.Interfaces;

namespace Project.Scripts.Input.Processorors.Impl
{
    public class TileInputProcessor : IInputProcessor
    {
        private IPlaceModel _placeModel;
        private IFaceDataProvider _faceDataProvider;

        public TileInputProcessor(IPlaceModel placeModel)
        {
            _placeModel = placeModel;
        }

        public void Click(ITouchable target)
        {
            var cubeToPlace = _placeModel.SelectedCube;
            if (cubeToPlace != null && target is TileView tile)
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
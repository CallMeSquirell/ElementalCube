using Framework.BindableProperties;
using Project.Scripts.GamePlay.Cube.Data;

namespace Project.Scripts.GamePlay.Tile
{
    public class TileData : ITileData
    {
        private readonly BindableProperty<ICubeData> _placedCube;
        public IBindableProperty<ICubeData> PlacedCube => _placedCube;
        
        public TileData(ICubeData placedCube)
        {
            _placedCube = new BindableProperty<ICubeData>(placedCube);
        }

        public void PlaceCube(ICubeData cubeData)
        {
            _placedCube.Value = cubeData;
        }
    }
}
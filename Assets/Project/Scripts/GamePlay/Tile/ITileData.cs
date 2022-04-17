using Project.Scripts.Framework.BindableProperties;
using Project.Scripts.GamePlay.Cube.Data;

namespace Project.Scripts.GamePlay.Tile
{
    public interface ITileData
    {
        IBindableProperty<ICubeData> PlacedCube { get; }

        void PlaceCube(ICubeData cubeData);
    }
}
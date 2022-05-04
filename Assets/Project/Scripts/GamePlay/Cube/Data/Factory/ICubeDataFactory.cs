using Project.Scripts.GamePlay.Cube.Data.Stats;

namespace Project.Scripts.GamePlay.Cube.Data.Factory
{
    public interface ICubeDataFactory
    {
        ICubeData Create(ICubeInfo cubeInfo);
    }
}
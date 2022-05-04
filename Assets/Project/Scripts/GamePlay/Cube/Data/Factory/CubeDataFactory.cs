using Project.Scripts.GamePlay.Cube.Data.Stats;

namespace Project.Scripts.GamePlay.Cube.Data.Factory
{
    public class CubeDataFactory : ICubeDataFactory
    {
        public ICubeData Create(ICubeInfo cubeInfo)
        {
            return new CubeData(cubeInfo.Faces,
                cubeInfo);
        }
    }
}
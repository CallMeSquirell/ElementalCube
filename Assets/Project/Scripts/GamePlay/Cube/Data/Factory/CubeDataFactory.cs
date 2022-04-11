using Project.Scripts.GamePlay.Cube.Data.Face.Provider;
using Project.Scripts.GamePlay.Cube.Data.Stats;

namespace Project.Scripts.GamePlay.Cube.Data.Factory
{
    public class CubeDataFactory : ICubeDataFactory
    {
        private readonly IFaceDataProvider _faceDataProvider;

        public CubeDataFactory(IFaceDataProvider faceDataProvider)
        {
            _faceDataProvider = faceDataProvider;
        }

        public ICubeData Create(CubeStats cubeInfo)
        {
            return new CubeData(_faceDataProvider.Provide(cubeInfo.Faces),
                cubeInfo);
        }
    }
}
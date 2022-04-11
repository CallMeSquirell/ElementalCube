using Project.Scripts.Framework.MVP.DI.Binding;
using Project.Scripts.Framework.MVP.Installers;
using Project.Scripts.GamePlay.Cube.Data.Face.Provider;
using Project.Scripts.GamePlay.Cube.Data.Factory;
using Project.Scripts.GamePlay.Cube.Factory;

namespace Project.Scripts.GamePlay.Cube.Installer
{
    public class CubeInstaller : MVPInstaller
    {
        public CubeInstaller(IPresenterContainer presenterContainer) : base(presenterContainer)
        {
        }

        protected override void InstallCommon()
        {
            Container.Bind<ICubeFactory>().To<CubeFactory>();
            Container.Bind<IFaceDataProvider>().To<FaceDataProvider>();
            Container.Bind<ICubeDataFactory>().To<CubeDataFactory>();
        }
    }
}
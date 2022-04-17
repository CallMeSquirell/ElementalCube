using Project.Scripts.Framework.MVP.DI.Binding;
using Project.Scripts.Framework.MVP.Installers;
using Project.Scripts.GamePlay.Cube.Data.Faces.Provider;
using Project.Scripts.GamePlay.Cube.Data.Factory;

namespace Project.Scripts.GamePlay.Cube.Installer
{
    public class CubeInstaller : MVPInstaller
    {
        public CubeInstaller(IPresenterContainer presenterContainer) : base(presenterContainer)
        {
        }

        protected override void InstallCommon()
        {
            Container.Bind<IFaceDataProvider>().To<FaceDataProvider>();
            Container.Bind<ICubeDataFactory>().To<CubeDataFactory>();
        }
    }
}
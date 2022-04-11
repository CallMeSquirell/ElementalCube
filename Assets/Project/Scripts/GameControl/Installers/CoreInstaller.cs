using Project.Scripts.Framework.MVP.DI.Binding;
using Project.Scripts.Framework.MVP.Installers;
using Project.Scripts.GameControl.Models;

namespace Project.Scripts.GameControl.Installers
{
    public class CoreInstaller : MVPInstaller
    {
        public CoreInstaller(IPresenterContainer presenterContainer) : base(presenterContainer)
        {
           
        }

        protected override void InstallModels()
        {
            Container.Bind<ICubeSetModel>().To<CubeSetModel>();
            Container.Bind<IPlaceModel>().To<PlaceModel>();
        }
    }
}
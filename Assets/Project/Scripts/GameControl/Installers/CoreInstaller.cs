using Framework.ResourceManagement;
using Framework.UI.Manager;
using Framework.UI.MVP.DI.Binding;
using Framework.UI.MVP.Installers;
using Project.Scripts.GameControl.Loader;
using Project.Scripts.GameControl.Models;
using Project.Scripts.Input.Models;

namespace Project.Scripts.GameControl.Installers
{
    public class CoreInstaller : MVPInstaller
    {
        public CoreInstaller(IPresenterContainer presenterContainer) : base(presenterContainer)
        {
           
        }

        protected override void InstallCommon()
        {
            Container.Bind<IUIManager>().To<UIManager>().AsSingle();
            Container.Bind<IInputStrategyProvider>().To<InputStrategyProvider>().AsSingle();
            Container.Bind<IAssetManager>().To<AssetManager>().AsSingle();
            Container.Bind<IConfig>().To<Config>().AsSingle();
            Container.Bind<ILevelLoader>().To<LevelLoader>().AsSingle();
        }

        protected override void InstallModels()
        {
            
        }
    }
}
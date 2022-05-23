using Framework.ResourceManagement;
using Framework.UI.Manager;
using Framework.UI.MVP.DI.Binding;
using Framework.UI.MVP.Installers;
using Project.Scripts.Configs;
using Project.Scripts.GameControl;
using Project.Scripts.GameControl.Loader;
using Project.Scripts.GameControl.Watchers;
using Project.Scripts.GamePlay.Models;
using Project.Scripts.GamePlay.UI.Input.Models;

namespace Project.Scripts.Installers
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
            Container.Bind<IWatcherManager>().To<WatcherManager>().AsSingle();
            Container.BindInterfacesTo<BootstrapController>().AsSingle();
        }

        protected override void InstallModels()
        {
            Container.Bind<IPlayerModel>().To<PlayerModel>().AsSingle();
        }
    }
}
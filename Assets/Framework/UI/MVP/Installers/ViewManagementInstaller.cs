using Framework.UI.MVP.DI;
using Framework.UI.MVP.DI.Binding;
using Framework.UI.MVP.DI.Provider;
using Zenject;

namespace Framework.UI.MVP.Installers
{
    public class ViewManagementInstaller : Installer
    {
        public override void InstallBindings()
        {
            InstallDI();
            BindManagers();
        }

        private void BindManagers()
        {
            Container.BindInterfacesTo<CoroutineManager.CoroutineManager>().AsSingle();
        }

        private void InstallDI()
        {
            Container.Bind<IPresenterProvider>().To<PresenterProvider>().AsSingle();
            Container.Bind<IViewFactory>().To<ViewFactory>().AsSingle();
            Container.Bind<IPresenterContainer>()
                .To<PresenterContainer>()
                .AsSingle()
                .When(context => context.ObjectType == typeof(PresenterProvider) ||
                                 context.ObjectType.IsSubclassOf(typeof(MVPInstaller)));
        }
    }
}
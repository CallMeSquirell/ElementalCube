using Project.Scripts.Framework.Manager;
using Project.Scripts.Framework.MVP.DI;
using Project.Scripts.Framework.MVP.DI.Binding;
using Project.Scripts.Framework.MVP.DI.Provider;
using Zenject;

namespace Project.Scripts.Framework.MVP.Installers
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
            Container.BindInterfacesTo<CoroutineManager>().AsSingle();
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
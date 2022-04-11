using Zenject;

namespace Project.Scripts.Framework.ResourceManagement
{
    public class ResourceManagementInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.Bind<IConfig>().To<Config>();
        }
    }
}
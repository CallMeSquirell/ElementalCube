using Project.Scripts.Framework.MVP.Installers;
using Project.Scripts.Framework.ResourceManagement;
using Project.Scripts.GamePlay.Cube.Installer;
using Zenject;

namespace Project.Scripts.GameControl.Installers
{
    public class GlobalInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            InstallNestedInstallers();
        }

        private void InstallNestedInstallers()
        {
            Container.Install<ViewManagementInstaller>();
            Container.Install<ResourceManagementInstaller>();
            Container.Install<CoreInstaller>();
            Container.Install<CubeInstaller>();
        }
    }
}
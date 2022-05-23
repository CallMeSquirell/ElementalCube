using Framework.UI.MVP.Installers;
using Project.Scripts.GamePlay.Installers;
using Zenject;

namespace Project.Scripts.Installers
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
            Container.Install<CoreInstaller>();
            Container.Install<GamePlayInstaller>();
        }
    }
}
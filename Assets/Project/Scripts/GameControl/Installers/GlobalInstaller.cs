using Framework.UI.MVP.Installers;
using Project.Scripts.GamePlay;
using Project.Scripts.UI.PlaceTile;
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
            Container.Install<CoreInstaller>();
            Container.Install<GamePlayInstaller>();
        }
    }
}
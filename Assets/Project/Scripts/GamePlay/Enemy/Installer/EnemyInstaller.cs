using Project.Scripts.Framework.MVP.DI.Binding;
using Project.Scripts.Framework.MVP.Installers;

namespace Project.Scripts.GamePlay.Enemy
{
    public class EnemyInstaller : MVPInstaller
    {
        public EnemyInstaller(IPresenterContainer presenterContainer) : base(presenterContainer)
        {
        }

        protected override void InstallCommon()
        {
        }
    }
}
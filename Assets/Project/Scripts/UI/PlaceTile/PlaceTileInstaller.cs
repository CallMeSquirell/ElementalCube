using Project.Scripts.Framework.MVP.DI.Binding;
using Project.Scripts.Framework.MVP.Installers;
using Project.Scripts.UI.PlaceTile.Views;

namespace Project.Scripts.UI.PlaceTile
{
    public class PlaceTileInstaller : MVPInstaller
    {
        public PlaceTileInstaller(IPresenterContainer presenterContainer) : base(presenterContainer)
        {
        }

        protected override void InstallPresenters(IPresenterContainer presenterContainer)
        {
            presenterContainer.BindView<PlaceTilePopUpView>().To<PlaceTilePopUpPresenter>();
        }
    }
}
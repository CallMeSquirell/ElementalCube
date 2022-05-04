using Framework.UI.MVP.DI.Binding;
using Framework.UI.MVP.Installers;
using Project.Scripts.Framework.ResourceManagement.Game.GameScreen;
using Project.Scripts.Framework.ResourceManagement.Game.GameScreen.Models;
using Project.Scripts.GameControl.Models;
using Project.Scripts.GamePlay.Cube.Data.Elements;
using Project.Scripts.GamePlay.Cube.Data.Factory;
using Project.Scripts.GamePlay.Health.Hits.Pool;
using Project.Scripts.GamePlay.Models;
using Project.Scripts.UI.PlaceTile.Views;

namespace Project.Scripts.GamePlay
{
    public class GamePlayInstaller : MVPInstaller
    {
        public GamePlayInstaller(IPresenterContainer presenterContainer) : base(presenterContainer)
        {
        }

        protected override void InstallPresenters(IPresenterContainer presenterContainer)
        {
            presenterContainer.BindView<PlaceTilePopUpView>().To<PlaceTilePopUpPresenter>();
            presenterContainer.BindView<GameScreenView>().To<GameScreenPresenter>();
        }

        protected override void InstallCommon()
        {
            Container.Bind<ICubeDataFactory>().To<CubeDataFactory>().AsSingle();
            Container.Bind<IElementProvider>().To<ElementProvider>().AsSingle();
            Container.Bind<IHitPool>().To<HitPool>().AsSingle();
        }

        protected override void InstallModels()
        {
            Container.Bind<ICubeSetModel>().To<CubeSetModel>().AsSingle();
            Container.Bind<IGameModel>().To<GameModel>().AsSingle();
            Container.Bind<IPlacedCubeModel>().To<PlacedCubesModel>().AsSingle();
            Container.Bind<IEnemyModel>().To<EnemyModel>().AsSingle();
        }
    }
}
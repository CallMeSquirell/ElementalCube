using Framework.UI.MVP.DI.Binding;
using Framework.UI.MVP.Installers;
using Project.Scripts.GameControl.Models;
using Project.Scripts.GamePlay.Cube.Data.Elements;
using Project.Scripts.GamePlay.Cube.Data.Factory;
using Project.Scripts.GamePlay.Health.Hits.Pool;
using Project.Scripts.GamePlay.LevelSystem.Spawners;
using Project.Scripts.GamePlay.Models;
using Project.Scripts.GamePlay.UI;
using Project.Scripts.GamePlay.UI.GameScreen.View;
using Project.Scripts.GamePlay.UI.PlaceTile.Views;
using Project.Scripts.GamePlay.UI.Reroll;
using Project.Scripts.GamePlay.UI.Result;
using Project.Scripts.GamePlay.UI.Settings;
using Project.Scripts.GamePlay.UI.StartScreen;

namespace Project.Scripts.GamePlay.Installers
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
            presenterContainer.BindView<RerollPopUpView>().To<RerollPopUpPresenter>();
            presenterContainer.BindView<ResultScreenView>().To<ResultScreenPresenter>();
            presenterContainer.BindView<StartScreenView>().To<StartScreenPresenter>();
            presenterContainer.BindView<SettingsView>().To<SettingsPresenter>();
        }

        protected override void InstallCommon()
        {
            Container.Bind<ICubeDataFactory>().To<CubeDataFactory>().AsSingle();
            Container.Bind<IEnemyFactory>().To<EnemyFactory>().AsSingle();
            Container.Bind<IElementProvider>().To<ElementProvider>().AsSingle();
            Container.Bind<IHitPool>().To<HitPool>().AsSingle();
        }

        protected override void InstallModels()
        {
            Container.Bind<ICubeSetModel>().To<CubeSetModel>().AsSingle();
            Container.Bind<IGameModel>().To<GameModel>().AsSingle();
            Container.Bind<IEnemyModel>().To<EnemyModel>().AsSingle();
            Container.Bind<ITownHallModel>().To<TownHallModel>().AsSingle();
            Container.Bind<IInGameEnergyModel>().To<InGameEnergyModel>().AsSingle();
        }
    }
}
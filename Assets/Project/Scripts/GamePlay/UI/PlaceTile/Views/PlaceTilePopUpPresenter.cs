using Framework.UI.MVP.Views.Core;
using Project.Scripts.GameControl.Models;
using Project.Scripts.GamePlay.Cube.Data.Factory;
using Project.Scripts.GamePlay.Cube.Data.Stats;
using Project.Scripts.GamePlay.Tile;

namespace Project.Scripts.UI.PlaceTile.Views
{
    public class PlaceTilePopUpPresenter : Presenter<PlaceTilePopUpView>
    {
        private readonly ICubeDataFactory _dataFactory;
        private readonly ITileData _tileData;
        private readonly ICubeSetModel _cubeSetModel;


        public PlaceTilePopUpPresenter(PlaceTilePopUpView view, 
            ICubeDataFactory dataFactory,
            ITileData tileData, 
            ICubeSetModel cubeSetModel
        ) : base(view)
        {
            _dataFactory = dataFactory;
            _tileData = tileData;
            _cubeSetModel = cubeSetModel;
        }

        public override void Initialise()
        {
            View.PlaceClicked += OnViewPlaceClicked;
            View.CloseClicked += OnViewCloseClicked;

            SetUpList();
        }

        private void SetUpList()
        {
            View.SetData(_cubeSetModel.AvailableCubeData);
        }

        private void OnViewPlaceClicked(ICubeInfo data)
        {
            _tileData.PlaceCube(_dataFactory.Create(data));
            _cubeSetModel.Retain(data);
            View.CloseView();
        }
        
        private void OnViewCloseClicked()
        {
           View.CloseView();
        }

        public override void Dispose()
        {
            View.PlaceClicked -= OnViewPlaceClicked;
            View.CloseClicked += OnViewCloseClicked;
        }
    }
}
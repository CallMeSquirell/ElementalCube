using Project.Scripts.Framework.MVP.Views;
using Project.Scripts.GameControl.Models;
using Project.Scripts.GamePlay.Cube.Data;

namespace Project.Scripts.UI.PlaceTile.Views
{
    public class PlaceTilePopUpPresenter : Presenter<PlaceTilePopUpView>
    {
        private readonly IPlaceModel _placeModel;

        public PlaceTilePopUpPresenter(PlaceTilePopUpView view,
            IPlaceModel placeModel) : base(view)
        {
            _placeModel = placeModel;
        }

        public override void Initialise()
        {
            View.PlaceClicked += OnViewPlaceClicked;
            View.CloseClicked += OnViewCloseClicked;
        }

        private void OnViewPlaceClicked(ICubeData data)
        {
            _placeModel.SelectedCube = data;
            OnViewCloseClicked();
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
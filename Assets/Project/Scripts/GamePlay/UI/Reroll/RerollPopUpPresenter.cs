using Framework.UI.MVP.Views.Core;
using Project.Scripts.Constants;
using Project.Scripts.GameControl.Models;
using Project.Scripts.GamePlay.Models;

namespace Project.Scripts.GamePlay.UI.Reroll
{
    public class RerollPopUpPresenter : Presenter<RerollPopUpView>
    {
        private readonly RerollPopUpPayload _payload;
        private readonly ICubeSetModel _cubeSetModel;
        private readonly IInGameEnergyModel _inGameEnergyModel;

        public RerollPopUpPresenter(RerollPopUpView view, 
            RerollPopUpPayload payload,
            ICubeSetModel cubeSetModel,
            IInGameEnergyModel inGameEnergyModel) : base(view)
        {
            _payload = payload;
            _cubeSetModel = cubeSetModel;
            _inGameEnergyModel = inGameEnergyModel;
        }

        public override void Initialise()
        {
            View.RerollClicked += OnRerollClicked;
            View.DeleteClicked += OnDeleteClicked;
            View.CloseClicked += OnCloseClicked;
        }

        private void OnCloseClicked()
        {
            View.CloseView();
        }

        private void OnDeleteClicked()
        {
            if (_inGameEnergyModel.TryPay(EnergyCosts.DeleteCost))
            {
                var placedCube = _payload.TileData.PlacedCube.Value; 
                _cubeSetModel.Release(placedCube.Info);
                _payload.TileData.PlaceCube(null);
            }
            OnCloseClicked();
        }

        private void OnRerollClicked()
        {
            if (_inGameEnergyModel.TryPay(EnergyCosts.RerollCost))
            {
                _payload.TileData.PlacedCube.Value.Reroll();
            }
            OnCloseClicked();
        }
        
        public override void Dispose()
        {
            View.RerollClicked -= OnRerollClicked;
            View.DeleteClicked -= OnDeleteClicked;
            View.CloseClicked -= OnCloseClicked;
        }

    }
}
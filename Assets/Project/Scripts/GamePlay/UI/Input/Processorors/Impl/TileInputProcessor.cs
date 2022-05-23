using Framework.UI.Manager;
using Project.Scripts.Constants;
using Project.Scripts.GamePlay.Tile.Views;
using Project.Scripts.GamePlay.UI.Input.System;
using Project.Scripts.GamePlay.UI.Reroll;

namespace Project.Scripts.GamePlay.UI.Input.Processorors.Impl
{
    public class TileInputProcessor : IInputProcessor
    {
        private readonly IUIManager _uiManager;
        
        public TileInputProcessor(
            IUIManager uiManager)
        {
            _uiManager = uiManager;
        }

        public void Click(ITouchable target)
        {
            if (target is TileView tile)
            {
                if (tile.Data.PlacedCube.Value == null)
                {
                    _uiManager.OpenView(RegisteredViews.PlaceCubePopUp, tile.Data);
                }
                else
                {
                    if (!tile.Data.PlacedCube.Value.IsUntargetable)
                    {
                        _uiManager.OpenView(RegisteredViews.RerollPopUp, new RerollPopUpPayload(tile.Data));
                    }
                }
            }
           
        }

        public void TouchStarted(ITouchable target)
        {
            
        }

        public void TouchEnded(ITouchable target)
        {
            
        }
    }
}
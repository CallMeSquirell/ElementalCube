using Framework.UI.Manager;
using Project.Scripts.Framework.ResourceManagement;
using Project.Scripts.GamePlay.Tile;
using Project.Scripts.Input.Interfaces;

namespace Project.Scripts.Input.Processorors.Impl
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
            if (target is TileView tile && 
                tile.Data.PlacedCube.Value == null)
            {
                _uiManager.OpenView(RegisteredViews.PlaceCubePopUp, tile.Data);
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
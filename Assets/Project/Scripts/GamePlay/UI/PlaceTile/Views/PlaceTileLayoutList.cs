using System;
using Framework.UI.Utils.LayoutListUtil;
using Project.Scripts.GamePlay.Cube.Data.Stats;

namespace Project.Scripts.GamePlay.UI.PlaceTile.Views
{
    public class PlaceTileLayoutList : LayoutList<CubeSelectReferenceView, ICubeInfo>
    {
        public event Action<ICubeInfo> Selected;

        protected override void SubscribeOnItem(CubeSelectReferenceView item)
        {
            item.Selected += OnItemSelected;
        }
        
        private void OnItemSelected(CubeSelectReferenceView item)
        {
            Selected?.Invoke(item.Data);
        }

        protected override void UnSubscribeFromItem(CubeSelectReferenceView item)
        {
            item.Selected -= OnItemSelected;
        }
    }
}
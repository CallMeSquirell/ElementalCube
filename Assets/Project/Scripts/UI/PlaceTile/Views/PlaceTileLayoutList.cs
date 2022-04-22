using System;
using Project.Scripts.Framework.UI.Utils;
using Project.Scripts.GamePlay.Cube.Data;

namespace Project.Scripts.UI.PlaceTile.Views
{
    public class PlaceTileLayoutList : LayoutList<CubeSelectReferenceView, ICubeData>
    {
        public event Action<ICubeData> Selected;

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
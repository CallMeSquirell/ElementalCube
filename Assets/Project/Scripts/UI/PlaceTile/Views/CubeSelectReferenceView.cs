using System;
using Project.Scripts.Framework.UI.Utils;
using Project.Scripts.GamePlay.Cube.Data;
using UnityEngine.EventSystems;

namespace Project.Scripts.UI.PlaceTile.Views
{
    public class CubeSelectReferenceView : LayoutListItem<ICubeData>, IPointerDownHandler
    {
        public event Action<CubeSelectReferenceView> Selected;

        public void OnPointerDown(PointerEventData eventData)
        {
            Selected?.Invoke(this);
        }
    }
}
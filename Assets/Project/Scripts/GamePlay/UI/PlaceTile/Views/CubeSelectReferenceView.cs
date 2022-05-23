using System;
using Framework.UI.Utils.LayoutListUtil;
using Project.Scripts.GamePlay.Cube.Data.Stats;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts.GamePlay.UI.PlaceTile.Views
{
    public class CubeSelectReferenceView : LayoutListItem<ICubeInfo>
    {
        public event Action<CubeSelectReferenceView> Selected;

        [SerializeField] private Button _selectButton;
        
        private void Awake()
        {
            _selectButton.onClick.AddListener(OnSelected);
        }

        private void OnSelected()
        {
            Selected?.Invoke(this);
        }

        private void OnDestroy()
        {
            _selectButton.onClick.RemoveListener(OnSelected);
        }
    }
}
using System;
using Project.Scripts.Framework.MVP.Views;
using Project.Scripts.GamePlay.Cube.Data;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts.UI.PlaceTile.Views
{
    public class PlaceTilePopUpView : PopUpView
    {
        public event Action<ICubeData> PlaceClicked;
        
        [SerializeField] private PlaceTileLayoutList _layoutList;

        [SerializeField] private Button _placeButton;

        private ICubeData _data;
        
        protected override void Awake()
        {
            base.Awake();
            _layoutList.Selected += OnDataSelected;
            _placeButton.onClick.AddListener(OnPlaceButtonClicked);
            ChangePlaceButtonState(false);
        }

        private void OnPlaceButtonClicked()
        {
            PlaceClicked?.Invoke(_data);
        }

        private void OnDataSelected(ICubeData data)
        {
            _data = data;
            ChangePlaceButtonState(true);
        }

        private void ChangePlaceButtonState(bool isActive)
        {
            _placeButton.gameObject.SetActive(isActive);
        }

        protected override void OnDestroy()
        {
            _layoutList.Selected -= OnDataSelected;
            _placeButton.onClick.RemoveListener(OnPlaceButtonClicked);
            base.OnDestroy();
        }
    }
}
using System;
using System.Collections.Generic;
using Framework.UI.MVP.Views.PopUp;
using Project.Scripts.GamePlay.Cube.Data.Stats;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts.UI.PlaceTile.Views
{
    public class PlaceTilePopUpView : PopUpView
    {
        public event Action<ICubeInfo> PlaceClicked;
        
        [SerializeField] private PlaceTileLayoutList _layoutList;

        [SerializeField] private Button _placeButton;

        private ICubeInfo _data;
        
        protected override void Awake()
        {
            base.Awake();
            _layoutList.Selected += OnDataSelected;
            _placeButton.onClick.AddListener(OnPlaceButtonClicked);
            ChangePlaceButtonState(false);
        }

        public void SetData(IEnumerable<ICubeInfo> cubeDataList)
        {
            _layoutList.SetData(cubeDataList);
        }

        private void OnPlaceButtonClicked()
        {
            PlaceClicked?.Invoke(_data);
        }

        private void OnDataSelected(ICubeInfo data)
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
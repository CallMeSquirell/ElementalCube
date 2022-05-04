using System;
using Framework.Extensions;
using Framework.UI.MVP.Views.Core;
using UnityEngine;
using UnityEngine.UI;

namespace Framework.UI.MVP.Views.PopUp
{
    public class PopUpView : ScreenBaseView, IPopUpView
    {
        public event Action CloseClicked;

        [SerializeField] private Button _closeButton;

        protected virtual void Awake()
        {
            if (_closeButton.NonNull())
            {
                _closeButton.onClick.AddListener(OnCloseButtonClicked);
            }
        }

        private void OnCloseButtonClicked()
        {
            CloseClicked?.Invoke();
        }

        protected virtual void OnDestroy()
        {
            if (_closeButton.NonNull())
            {
                _closeButton.onClick.RemoveListener(OnCloseButtonClicked);
            }
        }
    }
}
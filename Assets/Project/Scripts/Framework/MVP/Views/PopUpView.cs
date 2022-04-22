using System;
using Project.Scripts.Framework.Extensions;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts.Framework.MVP.Views
{
    public class PopUpView : ManagedView, IPopUpView
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
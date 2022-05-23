using System;
using Framework.UI.MVP.Views.Core;
using Framework.UI.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts.GamePlay.UI.Reroll
{
    public class RerollPopUpView : ScreenBaseView
    {
        public event Action CloseClicked; 
        public event Action DeleteClicked; 
        public event Action RerollClicked; 
        
        [SerializeField] private ActionPanel _panel;
        [SerializeField] private Button _reroll;
        [SerializeField] private Button _delete;

        protected override void Awake()
        {
            base.Awake();
            _delete.onClick.AddListener(OnDeleteClicked);
            _reroll.onClick.AddListener(OnRerollClicked);
            _panel.Clicked += OnCloseClicked;
        }

        private void OnRerollClicked()
        {
            RerollClicked?.Invoke();
        }

        private void OnDeleteClicked()
        {
            DeleteClicked?.Invoke();
        }

        private void OnCloseClicked()
        {
            CloseClicked?.Invoke();
        }

        private void OnDestroy()
        {
            _delete.onClick.RemoveListener(OnDeleteClicked);
            _reroll.onClick.RemoveListener(OnRerollClicked);
            _panel.Clicked -= OnCloseClicked;
        }
    }
}
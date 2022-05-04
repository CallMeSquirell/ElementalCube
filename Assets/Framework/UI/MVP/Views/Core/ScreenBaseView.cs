using System;
using Framework.Extensions;
using Framework.UI.Animations;
using UnityEngine;

namespace Framework.UI.MVP.Views.Core
{
    public class ScreenBaseView : MonoBehaviour, IScreenBaseView
    {
        public event Action<bool> FocusChanged;
        public event Action Opened;
        public event Action Closed;

        private bool _interactable;
        private BaseTransition _transition;
        public bool IsFocused { get; private set; } = true;

        public bool Interactable
        {
            set
            {
                _interactable = value;
                OnInteractableChanged(_interactable);
            }
        }

        private void Awake()
        {
            _transition = GetComponent<BaseTransition>();
        }

        private void Start()
        {
            if (_transition.NonNull())
            {
                _transition.PlayOpenTransition().Then(OnViewOpened);
            }
            else
            {
                OnViewOpened();
            }
        }

        private void OnViewOpened()
        {
            Opened?.Invoke();
        }

        public virtual void CloseView(bool withAnimation = true)
        {
            if (_transition.NonNull() && withAnimation)
            {
                _transition.PlayCloseTransition().Then(OnViewClosed);
            }
            else
            {
                OnViewClosed();  
            }
        }

        private void OnViewClosed()
        {
            Closed?.Invoke();
        }
        
        protected virtual void OnInteractableChanged(bool interactable)
        {
            _interactable = interactable;
        }

        public void SetFocus(bool isFocused)
        {
            if (isFocused != IsFocused)
            {
                IsFocused = isFocused;
                OnFocusChanged(isFocused);
                FocusChanged?.Invoke(isFocused);
            }
        }

        protected virtual void OnFocusChanged(bool isFocused)
        {
        }
    }
}
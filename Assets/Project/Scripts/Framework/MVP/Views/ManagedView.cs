using System;
using UnityEngine;

namespace Project.Scripts.Framework.MVP.Views
{
    public class ManagedView : MonoBehaviour, IManagedView
    {
        public event Action<IManagedView> Closed;

        public bool Interactable
        {
            set
            {
                _interactable = value;
                OnInteractableChanged(_interactable);
            }
        }
        
        private bool _interactable;

        public virtual void CloseView()
        {
            Closed?.Invoke(this);
            ClearView();
        }

        protected virtual void ClearView()
        {
            Destroy(gameObject);
        }

        protected virtual void OnInteractableChanged(bool interactable)
        {
            _interactable = interactable;
        }
    }
}
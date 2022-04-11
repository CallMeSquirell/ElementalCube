using Project.Scripts.Framework.Promises;
using UnityEngine;

namespace Project.Scripts.Framework.MVP.UI.Views
{
    public class WindowWindowView : MonoBehaviour, IWindowView
    {
        public IPromise Closed => _closePromise;

        private readonly Promise _closePromise = new Promise();
        
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
            _closePromise.Dispatch();
        }

        protected virtual void OnInteractableChanged(bool interactable)
        {
            _interactable = interactable;
        }

        private void OnDestroy()
        {
            CloseView();
        }
    }
}
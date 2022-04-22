using System;
using System.Linq;
using Project.Scripts.Framework.MVP.DI.Binding;
using Project.Scripts.Framework.MVP.Views;
using UnityEngine;

namespace Project.Scripts.Framework.MVP.DI.Provider
{
    public sealed class PresenterProvider : IPresenterProvider
    {
        private readonly IPresenterContainer _presenterContainer;

        public PresenterProvider(IPresenterContainer presenterContainer)
        {
            _presenterContainer = presenterContainer;
        }

        public void ProvideIncludeSubViesTo(IManagedView managedView, object payload = null)
        {
            var views = ((ManagedView) managedView).GetComponentsInChildren<ManagedView>(true);
            ProvideTo(managedView, payload);
            foreach (var subView in views.Skip(1))
            {
                ProvideTo(subView, null);
            }
        }
        
        public void ProvideTo(
            IManagedView managedView,
            object payload)
        {
            Type viewType = managedView.GetType();
            var binding = _presenterContainer.GetBinding(viewType);
            if (binding != null)
            {
                binding.CreatePresenter(managedView, payload);
                managedView.Closed += OnViewClosed;;
            }
            else
            {
                Debug.LogError($"Zenject has no binding for {viewType}");
            }
        }

        private void OnViewClosed(IManagedView managedView)
        {
            managedView.Closed -= OnViewClosed;
            Type viewType = managedView.GetType();
            _presenterContainer.GetBinding(viewType).DestroyPresenter(managedView);
        }
    }
}
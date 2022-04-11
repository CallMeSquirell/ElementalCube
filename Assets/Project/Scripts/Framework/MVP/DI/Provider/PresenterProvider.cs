using System;
using System.Linq;
using Project.Scripts.Framework.MVP.DI.Binding;
using Project.Scripts.Framework.MVP.UI.Views;
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

        public void ProvideIncludeSubViesTo(IWindowView windowView, object payload = null)
        {
            var views = ((WindowWindowView) windowView).GetComponentsInChildren<WindowWindowView>(true);
            ProvideTo(windowView, payload);
            foreach (var subView in views.Skip(1))
            {
                ProvideTo(subView, null);
            }
        }
        
        public void ProvideTo(
            IWindowView windowView,
            object payload)
        {
            Type viewType = windowView.GetType();
            var binding = _presenterContainer.GetBinding(viewType);
            if (binding != null)
            {
                binding.CreatePresenter(windowView, payload);
                windowView.Closed.Then(() => binding.DestroyPresenter(windowView));
            }
            else
            {
                Debug.LogError($"Zenject has no binding for {viewType}");
            }
        }

    }
}
using Project.Scripts.Framework.MVP.DI.Provider;
using Project.Scripts.Framework.MVP.UI.Views;
using UnityEngine;
using Zenject;

namespace Project.Scripts.Framework.MVP.DI
{
    public class ViewFactory : IViewFactory
    {
        private readonly IInstantiator _instantiator;
        private readonly IPresenterProvider _presenterProvider;

        public ViewFactory(IInstantiator instantiator, IPresenterProvider presenterProvider)
        {
            _instantiator = instantiator;
            _presenterProvider = presenterProvider;
        }

        public TView Create<TView>(ViewDefinition definition, object payload = null) where TView : IWindowView
        {
            return Create<TView>(definition, default, default, null, payload);
        }
        
        public TView Create<TView>(ViewDefinition definition, Transform parent, object payload = null) where TView : IWindowView
        {
            var view = _instantiator.InstantiatePrefabForComponent<TView>(definition.Prefab, parent);
            _presenterProvider.ProvideTo(view, payload);
            return view;
        }

        public TView Create<TView>(ViewDefinition definition, Vector3 position,
            Quaternion rotation = default,
            Transform parent = null, object payload = null) where TView : IWindowView
        {
            var view = _instantiator.InstantiatePrefabForComponent<TView>(definition.Prefab, position, rotation,
                parent);
            _presenterProvider.ProvideTo(view, payload);
            return view;
        }
    }
}
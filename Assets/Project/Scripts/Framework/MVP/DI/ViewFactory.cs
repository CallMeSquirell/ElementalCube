using Project.Scripts.Framework.MVP.DI.Provider;
using Project.Scripts.Framework.MVP.Views;
using Project.Scripts.Framework.ResourceManagement;
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

        public TView Create<TView>(IViewDefinition definition, object payload = null) where TView : IManagedView
        {
            return Create<TView>(definition, default, default, null, payload);
        }
        
        public TView Create<TView>(IViewDefinition definition, Transform parent, object payload = null) where TView : IManagedView
        {
            var view = _instantiator.InstantiatePrefabForComponent<TView>(definition.Prefab, parent);
            _presenterProvider.ProvideTo(view, payload);
            return view;
        }

        public TView Create<TView>(IViewDefinition definition, Vector3 position,
            Quaternion rotation = default,
            Transform parent = null, object payload = null) where TView : IManagedView
        {
            var view = _instantiator.InstantiatePrefabForComponent<TView>(definition.Prefab, position, rotation,
                parent);
            _presenterProvider.ProvideTo(view, payload);
            return view;
        }
    }
}
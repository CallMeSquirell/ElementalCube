using Project.Scripts.Framework.MVP.UI.Views;
using UnityEngine;

namespace Project.Scripts.Framework.MVP.DI
{
    public interface IViewFactory
    {
        TView Create<TView>(ViewDefinition definition, object payload = null) where TView : IWindowView;
        
        TView Create<TView>(ViewDefinition definition, Transform parent = null, object payload = null) where TView : IWindowView;
        TView Create<TView>(ViewDefinition definition, Vector3 position = default, Quaternion rotation = default,
            Transform parent = null, object payload = null) where TView : IWindowView;
    }
}
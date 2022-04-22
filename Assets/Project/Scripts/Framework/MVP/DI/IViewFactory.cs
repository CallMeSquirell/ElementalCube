using Project.Scripts.Framework.MVP.Views;
using Project.Scripts.Framework.ResourceManagement;
using UnityEngine;

namespace Project.Scripts.Framework.MVP.DI
{
    public interface IViewFactory
    {
        TView Create<TView>(IViewDefinition definition, object payload = null) where TView : IManagedView;
        
        TView Create<TView>(IViewDefinition definition, Transform parent = null, object payload = null) where TView : IManagedView;
        TView Create<TView>(IViewDefinition definition, Vector3 position = default, Quaternion rotation = default,
            Transform parent = null, object payload = null) where TView : IManagedView;
    }
}
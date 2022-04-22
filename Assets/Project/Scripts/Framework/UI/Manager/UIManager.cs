using System.Collections.Generic;
using System.Linq;
using Project.Scripts.Framework.MVP.Views;
using Project.Scripts.Framework.ResourceManagement;
using Project.Scripts.Framework.UI.Layer;
using UnityEngine;

namespace Project.Scripts.Framework.UI.Manager
{
    public class UIManager : MonoBehaviour, IUIManager
    {
        private readonly List<WindowLayer> _layers = new List<WindowLayer>();
        
        private void Awake()
        {
            _layers.AddRange(GetComponentsInChildren<WindowLayer>(true)
                .OrderBy(layer => layer.Order));
        }

        public void OpenView(IViewDefinition viewDefinition, object payload)
        {
            for (int i = _layers.Count - 1; i >= 0; i--)
            {
                var layer = _layers[i];
                if (layer.LayerType == viewDefinition.Layer)
                {
                    layer.PlaceView(viewDefinition, payload);
                    return;
                }
                else
                {
                    layer.PlaceView(null);
                }
            }
        }

        public IManagedView GetView(IViewDefinition viewDefinition)
        {
            foreach (var layer in _layers)
            {
                if (layer.CurrentViewDefinition == viewDefinition)
                {
                    return layer.PlacedView;
                }
            }

            return null;
        }
    }
}
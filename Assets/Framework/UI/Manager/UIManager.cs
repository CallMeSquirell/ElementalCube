using System.Collections.Generic;
using System.Linq;
using Framework.UI.Layer;
using Framework.UI.MVP.Views.Core;
using Framework.UI.MVP.Views.Data;
using Framework.UI.MVP.Views.ViewListeners;
using UnityEngine;

namespace Framework.UI.Manager
{
    public class UIManager : MonoBehaviour, IUIManager
    {
        private readonly List<WindowLayer> _layers = new List<WindowLayer>();

        private void Awake()
        {
            _layers.AddRange(GetComponentsInChildren<WindowLayer>(true)
                .OrderBy(layer => layer.Order));
            _layers.ForEach(layer => layer.Cleared += OnLayerCleared);
        }
        
        public IViewListener OpenView(IViewDefinition viewDefinition, object payload)
        {
            IViewListener listener = null;
            
            for (int i = _layers.Count - 1; i >= 0; i--)
            {
                WindowLayer layer = _layers[i];
                
                if (layer.LayerType == viewDefinition.LayerName)
                {
                    var data = new ViewData(viewDefinition, payload);
                    listener = data.Listener;
                    layer.PlaceView(data);
                    layer.SetFocus(true);
                    
                    for (;i >= 0; i--)
                    {
                        _layers[i].SetFocus(false);
                    }
                    break;
                }
                
                layer.Clear();
            }
            
            return listener;
        }

        public IScreenBaseView GetView(IViewDefinition viewDefinition)
        {
            foreach (var layer in _layers)
            {
                if (layer.PlacedViewData.Definition.Name.Equals(viewDefinition.Name))
                {
                    return layer.PlacedView;
                }
            }

            return null;
        }
        
        private void OnLayerCleared(WindowLayer layer)
        {
            for (int i = layer.Order; i >= 0; i--)
            {
                if (_layers[i].PlacedViewData != null)
                {
                    _layers[i].SetFocus(true);
                    return;
                }
            }
        }
    }
}
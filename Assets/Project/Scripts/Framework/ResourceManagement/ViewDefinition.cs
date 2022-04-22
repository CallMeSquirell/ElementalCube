using System;
using Project.Scripts.Framework.MVP.Views;
using Project.Scripts.Framework.UI;
using Project.Scripts.Framework.UI.Layer;
using UnityEngine;

namespace Project.Scripts.Framework.ResourceManagement
{
    [Serializable]
    public class ViewDefinition : IViewDefinition
    {
        [SerializeField] private ManagedView _prefab;
        [SerializeField] private WindowLayerEnum _layer;
        
        public ManagedView Prefab => _prefab;

        public WindowLayerEnum Layer { get; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using Project.Scripts.GamePlay.Cube.Data.Faces;
using UnityEngine;

namespace Project.Scripts.GameControl
{
    [CreateAssetMenu(fileName = "ElementConfig", menuName = "Config/Element")]
    public class ElementConfig : ScriptableObject
    {
        [SerializeField] private List<ElementInfo> _elementInfo = new List<ElementInfo>();
        
        public Color? GetElementColor(Element element)
        {
            return _elementInfo.FirstOrDefault(info => info.Element == element)?.Color;
        }
    }
    
    [Serializable]
    public class ElementInfo
    {
        [SerializeField] private Element _element;
        [SerializeField] private Color _color;

        public Element Element => _element;

        public Color Color => _color;
    }
}
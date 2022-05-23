using System;
using System.Collections.Generic;
using System.Linq;
using Project.Scripts.GamePlay.Cube.Data.Faces;
using UnityEngine;

namespace Project.Scripts.Configs
{
    [CreateAssetMenu(fileName = "ElementConfig", menuName = "Config/Element")]
    public class ElementConfig : ScriptableObject
    {
        [SerializeField] private List<ElementInfo> _elementInfo = new List<ElementInfo>();
        
        public Color? GetElementColor(Element element)
        {
            return _elementInfo.FirstOrDefault(info => info.Element == element)?.Color;
        }
        
        public ElementInfo GetElementInfo(Element element)
        {
            return _elementInfo.FirstOrDefault(info => info.Element == element);
        }
    }
    
    [Serializable]
    public class ElementInfo
    {
        [SerializeField] private Element _element;
        [SerializeField] private Sprite _sprite;
        [SerializeField] private Color _color;

        public Element Element => _element;

        public Sprite Sprite => _sprite;

        public Color Color => _color;
    }
}
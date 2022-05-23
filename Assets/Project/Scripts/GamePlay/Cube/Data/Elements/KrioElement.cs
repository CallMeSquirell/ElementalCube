using Project.Scripts.GamePlay.Cube.Data.Faces;
using UnityEngine;

namespace Project.Scripts.GamePlay.Cube.Data.Elements
{
    public class KrioElement : IElement
    {
        public Element Element { get; } = Element.Krio;
        
        public bool ApplyExtraDamage(Element element, int damage, out int result)
        {
           
            switch (element)
            {
                case Element.Electro:
                    result = (int) (damage * 2f);
                    return true;
                case Element.Piro:
                    result = Mathf.CeilToInt(damage * 1.5f);
                    break;
                default:
                    result = damage;
                    return false;
            }
            return true;
        }
    }
}
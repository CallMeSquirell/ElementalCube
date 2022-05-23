using Project.Scripts.GamePlay.Cube.Data.Faces;
using UnityEngine;

namespace Project.Scripts.GamePlay.Cube.Data.Elements
{
    public class PiroElement : IElement
    {
        public Element Element { get; } = Element.Piro;
        public bool ApplyExtraDamage(Element element, int damage, out int result)
        {
            switch (element)
            {
                case Element.Krio:
                    result = (int) (damage * 2f);
                    return true;
                case Element.Electro:
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
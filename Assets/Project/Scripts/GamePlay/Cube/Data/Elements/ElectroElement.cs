using Project.Scripts.GamePlay.Cube.Data.Faces;
using UnityEngine;

namespace Project.Scripts.GamePlay.Cube.Data.Elements
{
    public class ElectroElement : IElement
    {
        public Element Element => Element.Electro;

        public bool ApplyExtraDamage(Element element, int damage, out int result)
        {  
            switch (element)
            {
                case Element.Piro:
                    result = (int) (damage * 2f);
                    return true;
                case Element.Krio:
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
using Project.Scripts.GamePlay.Cube.Data.Faces;

namespace Project.Scripts.GamePlay.Cube.Data.Elements
{
    public class ElectroElement : IElement
    {
        public Element Element { get; } = Element.Electro;
        
        public bool ApplyExtraDamage(Element element, int damage, out int result)
        {  
            result = damage;
            switch (element)
            {
                case Element.Electro:
                    result = (int) (damage * 2f);
                    return true;
                case Element.Piro:
                    result = (int) (damage * 0.5f);
                    break;
            }

            return false;
        }
    }
}
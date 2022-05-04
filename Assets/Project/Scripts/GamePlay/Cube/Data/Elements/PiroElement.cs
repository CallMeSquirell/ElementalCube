using Project.Scripts.GamePlay.Cube.Data.Faces;

namespace Project.Scripts.GamePlay.Cube.Data.Elements
{
    public class PiroElement : IElement
    {
        public Element Element { get; } = Element.Piro;
        public bool ApplyExtraDamage(Element element, int damage, out int result)
        {
            result = damage;
            switch (element)
            {
                case Element.Krio:
                    result = (int) (damage * 2f);
                    return true;
                case Element.Electro:
                    result = (int) (damage * 0.5f);
                    break;
            }
            return false;
        }
    }
}
using Project.Scripts.GamePlay.Cube.Data.Faces;

namespace Project.Scripts.GamePlay.Cube.Data.Elements
{
    public class DefaultElement : IElement
    {
        public Element Element => Element.Empty;

        public bool ApplyExtraDamage(Element element, int damage, out int result)
        {
            result = damage;
            return false;
        }
    }
}
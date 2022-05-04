using Project.Scripts.GamePlay.Cube.Data.Faces;

namespace Project.Scripts.GamePlay.Cube.Data.Elements
{
    public interface IElement
    {
        Element Element { get; }
        bool ApplyExtraDamage(Element element, int damage , out int result);
    }
}
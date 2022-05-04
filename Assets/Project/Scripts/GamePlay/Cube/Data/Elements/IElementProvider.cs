using Project.Scripts.GamePlay.Cube.Data.Faces;

namespace Project.Scripts.GamePlay.Cube.Data.Elements
{
    public interface IElementProvider
    {
        IElement GetElement(Element element);
    }
}
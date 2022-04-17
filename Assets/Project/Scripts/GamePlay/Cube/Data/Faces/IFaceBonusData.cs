using Project.Scripts.GamePlay.Cube.Data.Element;

namespace Project.Scripts.GamePlay.Cube.Data.Faces
{
    public interface IFaceBonusData
    {
        IElementData Element { get; }
        void Process();
    }
}
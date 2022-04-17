using Project.Scripts.GamePlay.Cube.Data.Element;

namespace Project.Scripts.GamePlay.Cube.Data.Faces
{
    public class BaseFace : IFaceBonusData
    {
        public IElementData Element { get; set; }

        public BaseFace(IElementData element)
        {
            Element = element;
        }

        public virtual void Process()
        {
            
        }
    }
}
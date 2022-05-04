using System.Collections.Generic;
using Framework.Extensions;
using Project.Scripts.GamePlay.Cube.Data.Faces;

namespace Project.Scripts.GamePlay.Cube.Data.Elements
{
    public class ElementProvider : IElementProvider
    {
        private Dictionary<Element, IElement> _elementData = new Dictionary<Element, IElement>(
            new EnumComparator<Element>());

        public ElementProvider()
        {
            InitializeElements();
        }
        
        public IElement GetElement(Element element)
        {
            return _elementData[element];
        }
        
        private void InitializeElements()
        {
            _elementData.Add(Element.Krio, new KrioElement());
            _elementData.Add(Element.Piro, new PiroElement());
            _elementData.Add(Element.Electro, new ElectroElement());
        }
    }
}
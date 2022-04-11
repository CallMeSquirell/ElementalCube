using System;
using System.Collections.Generic;
using System.Linq;
using Project.Scripts.GamePlay.Cube.Data.Element;
using Zenject;

namespace Project.Scripts.GamePlay.Cube.Data.Face.Provider
{
    public class FaceDataProvider : IFaceDataProvider
    {
        private readonly IInstantiator _instantiator;
        private readonly IFactory<Type, BaseFace> _factory;

        private readonly Dictionary<Type, IElementData> _elements = 
            new Dictionary<Type, IElementData>();
        private readonly Dictionary<Type, IFaceBonusData> _faces =
            new Dictionary<Type, IFaceBonusData>();

        public FaceDataProvider(IInstantiator instantiator)
        {
            _instantiator = instantiator;
            InitElements();
            InitFaces();
        }

        private void InitElements()
        {
            AddElement<ElementData>();
        }
        
        private void InitFaces()
        {
            AddFace<BaseFace, ElementData>();
        }

        public IReadOnlyList<IFaceBonusData> Provide(IReadOnlyList<Type> types)
        {
            return types.Select(Provide).ToList();
        }

        private IFaceBonusData Provide(Type type)
        {
            return _faces[type];
        }
        
        private void AddFace<T,E>() where T : BaseFace where E : IElementData
        {
            var data = _instantiator.Instantiate<T>(new object[]{_elements[typeof(E)]});
            _faces.Add(typeof(T), data);
        }

        private void AddElement<T>() where T : IElementData
        {
            _elements.Add(typeof(T), _instantiator.Instantiate<T>());
        }
    }
}
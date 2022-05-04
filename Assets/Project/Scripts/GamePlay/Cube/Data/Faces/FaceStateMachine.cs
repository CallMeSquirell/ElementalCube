using System.Collections.Generic;
using Project.Scripts.GamePlay.Cube.Data.Elements;
using Project.Scripts.GamePlay.Cube.Data.Face;
using Project.Scripts.GamePlay.Cube.Data.Stats;
using Zenject;

namespace Project.Scripts.GamePlay.Cube.Data.Faces
{
    public class FaceStateMachine
    {
        private readonly IInstantiator _instantiator;
        private readonly IElementProvider _elementProvider;
        private readonly ICubeInfo _cubeState;

        private readonly Dictionary<FaceType, IFaceBonusData> _faces = new Dictionary<FaceType, IFaceBonusData>();
        private IFaceBonusData _currentFace;

        public IFaceBonusData CurrentFace => _currentFace;

        public FaceStateMachine(IInstantiator instantiator,
            IElementProvider elementProvider)
        {
            _instantiator = instantiator;
            _elementProvider = elementProvider;
        }

        public IFaceBonusData UpdateFace(FaceType type)
        {
            if (!_faces.TryGetValue(type, out IFaceBonusData faceBonusData))
            {
                var element = _elementProvider.GetElement(type.Element);
                faceBonusData = (IFaceBonusData) _instantiator.Instantiate(type.Bonus.ConvertToType(),
                    new List<object> {element});
                _faces.Add(type, faceBonusData);
            }

            _currentFace = faceBonusData;
            faceBonusData.Clear();
            return faceBonusData;
        }
    }
}
using System.Collections.Generic;
using Project.Scripts.Framework.BindableProperties;
using Project.Scripts.GamePlay.Cube.Data.Face;
using Project.Scripts.GamePlay.Cube.Data.Faces;
using Project.Scripts.GamePlay.Cube.Data.State;
using Project.Scripts.GamePlay.Cube.Data.Stats;
using UnityEngine;

namespace Project.Scripts.GamePlay.Cube.Data
{
    public class CubeData : ICubeData
    {
        private readonly BindableProperty<IFaceBonusData> _currentFace;
        public ICubeInfo Stats { get; }
        
        public CubeState State { get; } =  new CubeState();
        public IReadOnlyList<IFaceBonusData> Faces { get; }
        
        public IBindableProperty<IFaceBonusData> CurrentFace => _currentFace;
        private IFaceBonusData RandomFace => Faces[Random.Range(0, Faces.Count)];

        public CubeData(IReadOnlyList<IFaceBonusData> faces, ICubeInfo stats)
        {
            Faces = faces;
            Stats = stats;
            _currentFace = new BindableProperty<IFaceBonusData>(RandomFace);
        }

        public void Reroll()
        {
            _currentFace.Value = RandomFace;
        }
    }
}
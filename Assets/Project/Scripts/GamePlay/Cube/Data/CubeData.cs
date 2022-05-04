using System.Collections.Generic;
using Framework.BindableProperties;
using Project.Scripts.GamePlay.Cube.Data.Face;
using Project.Scripts.GamePlay.Cube.Data.Faces;
using Project.Scripts.GamePlay.Cube.Data.State;
using Project.Scripts.GamePlay.Cube.Data.Stats;
using UnityEngine;

namespace Project.Scripts.GamePlay.Cube.Data
{
    public class CubeData : ICubeData
    {
        private readonly BindableProperty<FaceType> _currentFace;
        public ICubeInfo Stats { get; }
        
        public CubeState State { get; } =  new CubeState();
        public IReadOnlyList<FaceType> Faces { get; }
        public IBindableProperty<FaceType> CurrentFace => _currentFace;
        private FaceType RandomFace => Faces[Random.Range(0, Faces.Count)];

        public CubeData(IReadOnlyList<FaceType> faces, ICubeInfo stats)
        {
            Faces = faces;
            Stats = stats;
            _currentFace = new BindableProperty<FaceType>(RandomFace);
        }

        public void Reroll()
        {
            _currentFace.Value = RandomFace;
        }
    }
}
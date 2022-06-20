using System.Collections.Generic;
using System.Linq;
using Framework.BindableProperties;
using Project.Scripts.GamePlay.Cube.Data.Faces;
using Project.Scripts.GamePlay.Cube.Data.State;
using Project.Scripts.GamePlay.Cube.Data.Stats;
using UnityEngine;

namespace Project.Scripts.GamePlay.Cube.Data
{
    public class CubeData : ICubeData
    {
        private readonly BindableProperty<FaceType> _currentFace;
        public ICubeInfo Info { get; }
        
        public CubeState State { get; } =  new CubeState();
        public IReadOnlyList<FaceType> Faces { get; }
        public IBindableProperty<FaceType> CurrentFace => _currentFace;
        private FaceType RandomFace => Faces.Where(face => face != _currentFace.Value).ToList()[Random.Range(0, Faces.Count)];

        public bool IsUntargetable { get; set; }

        public CubeData(IReadOnlyList<FaceType> faces, ICubeInfo stats)
        {
            Faces = faces;
            Info = stats;
            _currentFace = new BindableProperty<FaceType>(Faces[Random.Range(0, Faces.Count)]);
        }

        public void Reroll()
        {
            _currentFace.Value = RandomFace;
        }
    }
}
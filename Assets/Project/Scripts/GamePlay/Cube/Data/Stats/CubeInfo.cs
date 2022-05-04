using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Project.Scripts.GamePlay.Cube.Data.Face;
using Project.Scripts.GamePlay.Cube.Data.Faces;
using UnityEngine;

namespace Project.Scripts.GamePlay.Cube.Data.Stats
{
    [Serializable]
    public class CubeInfo : ICubeInfo
    {
        [SerializeField] private int _damage = 1;
        [SerializeField] private int _shotsPerSecond = 1;
        [SerializeField] private int _shootRange = 1;
        [SerializeField] private List<FaceType> _faces;
        
        public int Damage => _damage;
        public int ShotsPerSecond => _shotsPerSecond;
        public float ShootRange => _shootRange;
        
        public IReadOnlyList<FaceType> Faces => _faces;
    }
}
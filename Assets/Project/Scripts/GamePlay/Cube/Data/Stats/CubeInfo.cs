using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ModestTree;
using Project.Scripts.GamePlay.Cube.Data.Faces;
using UnityEngine;

namespace Project.Scripts.GamePlay.Cube.Data.Stats
{
    [CreateAssetMenu(fileName = "Cube", menuName = "Config/Cube")]
    public class CubeInfo : ScriptableObject, ICubeInfo
    {
        [SerializeField] private string _cubeName;
        [SerializeField] private Sprite _sprite;
        [SerializeField] private int _damage = 1;
        [SerializeField] private int _shotsPerSecond = 1;
        [SerializeField] private int _shootRange = 1;
        [SerializeField] private List<FaceType> _faces = new List<FaceType>(6);
        
        public int Damage => _damage;
        public int ShotsPerSecond => _shotsPerSecond;
        public float ShootRange => _shootRange;

        public string CubeName => _cubeName;

        public Sprite Sprite => _sprite;

        public IReadOnlyList<FaceType> Faces => _faces;
        
    }
}
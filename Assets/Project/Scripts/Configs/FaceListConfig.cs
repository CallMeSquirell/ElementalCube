using System;
using System.Collections.Generic;
using System.Linq;
using Project.Scripts.GamePlay.Cube.Data.Faces;
using UnityEngine;

namespace Project.Scripts.Configs
{
    [Serializable]
    public class FaceConfig
    {
        [SerializeField] private FaceType _faceType;
        [SerializeField] private Material _sprite;

        public FaceType FaceType => _faceType;

        public Material Sprite => _sprite;
    }

    [CreateAssetMenu(fileName = "FaceListConfig", menuName = "Config/FaceList", order = 0)]
    public class FaceListConfig : ScriptableObject
    {
        [SerializeField] private List<FaceConfig> _faceConfigs;

        public Material GetConfig(FaceType dataFace)
        {
            return _faceConfigs.FirstOrDefault(config => config.FaceType.Element == dataFace.Element).Sprite;
        }
    }
    
}
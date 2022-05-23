using System.Collections.Generic;
using Project.Scripts.GamePlay.Cube.Data.Stats;
using Project.Scripts.GamePlay.Cube.Views;
using UnityEngine;

namespace Project.Scripts.Configs
{
    [CreateAssetMenu(fileName = "CubeSetConfig", menuName = "Config/CubeConfig")]
    public class CubeSetConfig : ScriptableObject
    {
        [SerializeField] private CubeView _cubeView;
        [SerializeField] private List<CubeInfo> _cubeSet;

        public IReadOnlyList<CubeInfo> CubeSet => _cubeSet;

        public CubeView CubeView => _cubeView;
    }
}
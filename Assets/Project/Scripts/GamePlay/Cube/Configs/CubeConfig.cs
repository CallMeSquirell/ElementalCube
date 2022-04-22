using System.Collections.Generic;
using Project.Scripts.Framework.ResourceManagement;
using Project.Scripts.GamePlay.Cube.Data.Stats;
using Project.Scripts.GamePlay.Cube.Views;
using UnityEngine;

namespace Project.Scripts.GamePlay.Cube.Configs
{
    [CreateAssetMenu(fileName = "CubeConfig", menuName = "Config/Cube")]
    public class CubeConfig : ScriptableObject
    {
        [SerializeField] private CubeView _cubeView;
        [SerializeField] private List<CubeInfo> _cubeSet;

        public IReadOnlyList<CubeInfo> CubeSet => _cubeSet;

        public CubeView CubeView => _cubeView;
    }
}
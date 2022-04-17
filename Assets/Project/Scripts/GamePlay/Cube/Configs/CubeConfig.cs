using System.Collections.Generic;
using Project.Scripts.Framework.MVP.UI.Views;
using Project.Scripts.GamePlay.Cube.Data.Stats;
using UnityEngine;

namespace Project.Scripts.GamePlay.Cube.Configs
{
    [CreateAssetMenu(fileName = "CubeConfig", menuName = "Config/Cube")]
    public class CubeConfig : ScriptableObject
    {
        [SerializeField] private ViewDefinition _defenition;
        [SerializeField] private List<CubeInfo> _cubeSet;

        public IReadOnlyList<CubeInfo> CubeSet => _cubeSet;

        public ViewDefinition Defenition => _defenition;
    }
}
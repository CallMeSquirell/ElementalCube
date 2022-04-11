using Project.Scripts.Framework.MVP.UI.Views;
using Project.Scripts.GamePlay.Slime.Data.Stats;
using UnityEngine;

namespace Project.Scripts.GamePlay.Slime.Configs
{
    [CreateAssetMenu(fileName = "SlimeConfig", menuName = "Config/Slime")]
    public class SlimeConfig : ScriptableObject
    {
        [SerializeField] private ViewDefinition _prefab;
        [SerializeField] private SlimeStats _defaultStats;

        public ViewDefinition Prefab => _prefab;

        public SlimeStats DefaultStats => _defaultStats;
    }
}
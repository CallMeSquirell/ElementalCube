using Project.Scripts.Framework.MVP.UI.Views;
using Project.Scripts.GamePlay.Enemy.Data.Stats;
using UnityEngine;

namespace Project.Scripts.GamePlay.Enemy.Configs
{
    [CreateAssetMenu(fileName = "SlimeConfig", menuName = "Config/Slime")]
    public class EnemyConfig : ScriptableObject
    {
        [SerializeField] private ViewDefinition _definition;
        [SerializeField] private EnemyInfo _defaultStats;
        public ViewDefinition Definition => _definition;

        public EnemyInfo DefaultStats => _defaultStats;
    }
}
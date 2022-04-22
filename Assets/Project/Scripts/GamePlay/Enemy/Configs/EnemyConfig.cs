using Project.Scripts.Framework.ResourceManagement;
using Project.Scripts.GamePlay.Enemy.Data.Stats;
using Project.Scripts.GamePlay.Enemy.Views;
using UnityEngine;

namespace Project.Scripts.GamePlay.Enemy.Configs
{
    [CreateAssetMenu(fileName = "SlimeConfig", menuName = "Config/Slime")]
    public class EnemyConfig : ScriptableObject
    {
        [SerializeField] private EnemyView _definition;
        [SerializeField] private EnemyInfo _defaultStats;
        public EnemyView Definition => _definition;

        public EnemyInfo DefaultStats => _defaultStats;
    }
}
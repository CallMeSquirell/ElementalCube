using System.Collections.Generic;
using System.Linq;
using Project.Scripts.GamePlay.Enemy;
using Project.Scripts.GamePlay.Enemy.Data.Stats;
using UnityEngine;

namespace Project.Scripts.Configs
{
    [CreateAssetMenu(fileName = "EnemyConfig", menuName = "Config/Enemy")]
    public class EnemyConfig : ScriptableObject
    {
        [SerializeField] private List<EnemyInfo> _enemies;

        public EnemyInfo GetEnemyByType(EnemyType type)
        {
            return _enemies.FirstOrDefault(enemy => enemy.EnemyType == type);
        }
    }
    
}
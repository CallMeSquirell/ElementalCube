using Project.Scripts.GamePlay.LevelSystem.Spawners;
using Project.Scripts.GamePlay.LevelSystem.TownHalls;
using UnityEngine;
using Zenject;

namespace Project.Scripts.GamePlay.LevelSystem
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private EnemySpawner _enemySpawner;

        public EnemySpawner EnemySpawner => _enemySpawner;
    }
}
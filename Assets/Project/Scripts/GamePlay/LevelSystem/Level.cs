using Project.Scripts.GamePlay.LevelSystem.Spawners;
using Project.Scripts.GamePlay.LevelSystem.TownHalls;
using UnityEngine;
using Zenject;

namespace Project.Scripts.GamePlay.LevelSystem
{
    public class Level : MonoBehaviour, IInitializable
    {
        [SerializeField] private EnemySpawner _enemySpawner;
        
        public void Initialize()
        {
           _enemySpawner.Play();
        }
    }
}
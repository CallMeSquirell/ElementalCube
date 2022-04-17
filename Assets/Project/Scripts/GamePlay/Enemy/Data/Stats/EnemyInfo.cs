using System;
using UnityEngine;

namespace Project.Scripts.GamePlay.Enemy.Data.Stats
{
    [Serializable]
    public class EnemyInfo : IEnemyInfo
    {
        [SerializeField] private int _maxHealth = 5;
        [SerializeField] private float _speed = 3f;

        public int MaxHealth => _maxHealth;
        public float Speed => _speed;
    }
}
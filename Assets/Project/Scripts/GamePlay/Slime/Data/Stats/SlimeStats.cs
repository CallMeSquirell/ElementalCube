using System;
using UnityEngine;

namespace Project.Scripts.GamePlay.Slime.Data.Stats
{
    [Serializable]
    public class SlimeStats : ISlimeStats
    {
        [SerializeField] private int _maxHealth = 5;
        [SerializeField] private float _speed = 3f;

        public int MaxHealth => _maxHealth;
        public float Speed => _speed;
    }
}
using System;
using Project.Scripts.GamePlay.Cube.Data.Faces;
using Project.Scripts.GamePlay.Enemy.Views;
using UnityEngine;

namespace Project.Scripts.GamePlay.Enemy.Data.Stats
{
    [Serializable]
    public class EnemyInfo : IEnemyInfo
    {
        [SerializeField] private int _maxHealth = 5;
        [SerializeField] private float _speed = 3f;
        [SerializeField] private Sprite _sprite;
        [SerializeField] private EnemyView _prefab;
        [SerializeField] private EnemyType _enemyType;
        [SerializeField] private Element _element = Element.Empty;

        public Element Element => _element;
        public int MaxHealth => _maxHealth;
        public float Speed => _speed;
        public Sprite Sprite => _sprite;
        public EnemyType EnemyType => _enemyType;
        public EnemyView Prefab => _prefab;
    }
}
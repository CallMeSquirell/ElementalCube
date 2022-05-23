using System;
using System.Collections.Generic;
using Project.Scripts.GamePlay.Enemy;
using UnityEngine;

namespace Project.Scripts.GamePlay.LevelSystem
{
    [Serializable]
    public class LevelData
    {
        [SerializeField] private int _levelNumber = 1;
        [SerializeField] private List<EnemyPack> _packs = new List<EnemyPack>();

        public int LevelNumber => _levelNumber;

        public List<EnemyPack> Packs => _packs;
    }

    [Serializable]
    public class EnemyPack
    {
        [SerializeField] private EnemyType _type;
        [SerializeField] private int _count;

        public EnemyType Type => _type;

        public int Count => _count;
    }
}
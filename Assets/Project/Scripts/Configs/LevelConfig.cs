using System.Collections.Generic;
using System.Linq;
using Project.Scripts.GamePlay.LevelSystem;
using UnityEngine;

namespace Project.Scripts.Configs
{
    [CreateAssetMenu(fileName = "LevelConfig", menuName = "Config/Level")]
    public class LevelConfig : ScriptableObject
    {
        [SerializeField] public List<LevelData> _levelList;

        public List<LevelData> LevelList => _levelList;

        public LevelData GetDataByNumber(int number)
        {
            return _levelList.FirstOrDefault(level => level.LevelNumber == number);
        }
    }
}
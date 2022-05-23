using Project.Scripts.Configs;
using Project.Scripts.Constants;
using Project.Scripts.GamePlay.LevelSystem;
using UnityEngine;

namespace Project.Scripts.GamePlay.Models
{
    public class PlayerModel : IPlayerModel
    {
        private readonly IConfig _config;
        private LevelData _currentLevel;
        public LevelData CurrentLevel => _currentLevel ?? (_currentLevel = GetLevel());
        
        public PlayerModel(IConfig config)
        {
            _config = config;
        }

        public void CompleteLevel()
        {
            var nextLevel = _currentLevel.LevelNumber;
                            //+ 1;
            PlayerPrefs.SetInt(PlayerPrefsKeys.CurrentLevel,nextLevel);
            _currentLevel =  _config.Get<LevelConfig>().GetDataByNumber(nextLevel);
        }

        private LevelData GetLevel()
        {
           return _config.Get<LevelConfig>().GetDataByNumber(
               PlayerPrefs.GetInt(PlayerPrefsKeys.CurrentLevel, 1));
        }
    }
}
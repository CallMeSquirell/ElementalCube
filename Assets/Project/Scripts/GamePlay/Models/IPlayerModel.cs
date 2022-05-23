using Project.Scripts.GamePlay.LevelSystem;

namespace Project.Scripts.GamePlay.Models
{
    public interface IPlayerModel
    {
        LevelData CurrentLevel { get; }
        void CompleteLevel();
    }
}
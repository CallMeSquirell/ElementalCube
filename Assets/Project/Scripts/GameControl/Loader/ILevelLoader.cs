using Framework.Promises;
using Project.Scripts.GamePlay.LevelSystem;

namespace Project.Scripts.GameControl.Loader
{
    public interface ILevelLoader
    {
        IPromise LoadNextLevel(int levelIndex);
        void SetUpNextLevel();
        Level CreatedLevel { get; }
    }
}
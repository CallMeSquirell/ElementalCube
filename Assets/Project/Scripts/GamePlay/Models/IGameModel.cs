using Framework.BindableProperties;

namespace Project.Scripts.GamePlay.Models
{
    public interface IGameModel
    {
        IBindableProperty<bool> IsPlaying { get; }
        void ResumeGame();
        void PauseGame();
    }
}
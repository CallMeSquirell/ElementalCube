using Framework.BindableProperties;
using UnityEngine;

namespace Project.Scripts.GamePlay.Models
{
    public class GameModel : IGameModel
    {
        private readonly BindableProperty<bool> _isPlaying = new BindableProperty<bool>();
        public IBindableProperty<bool> IsPlaying => _isPlaying;

        public void ResumeGame()
        {
            Time.timeScale = 1;
            _isPlaying.Value = true;
        }

        public void PauseGame()
        {
            Time.timeScale = 0; 
            _isPlaying.Value = false;
        }
    }
}
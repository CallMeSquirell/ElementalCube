using UnityEngine;

namespace Project.Scripts.GamePlay.Models
{
    public class GameModel : IGameModel
    {
        public void ResumeGame()
        {
            Time.timeScale = 1;
        }

        public void PauseGame()
        {
            Time.timeScale = 0;
        }
    }
}
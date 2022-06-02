using System;
using Framework.UI.MVP.Views.Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts.GamePlay.UI.Result
{
    public class ResultScreenView : ScreenBaseView
    {
        public event Action NextLevelClicked;
        
        [SerializeField] private Button _nextLevel;
        [SerializeField] private TextMeshProUGUI _buttonText;
        [SerializeField] private TextMeshProUGUI _resultText;
        [SerializeField] private GameObject _winStars;

        protected override void Awake()
        {
            base.Awake();
            _nextLevel.onClick.AddListener(OnNextLevelClicked);
        }

        private void OnNextLevelClicked()
        {
            NextLevelClicked?.Invoke();
        }

        private void OnDestroy()
        {
            _nextLevel.onClick.RemoveListener(OnNextLevelClicked);
        }

        public void SetState(bool payloadIsWon)
        {
            if (payloadIsWon)
            {
                _buttonText.text = "Next Level";
                _resultText.text = "YOU WIN";
            }
            else
            {
                _buttonText.text = "Restart";
                _resultText.text = "YOU LOSE";
            }
            _winStars.SetActive(payloadIsWon);
        }
    }
}
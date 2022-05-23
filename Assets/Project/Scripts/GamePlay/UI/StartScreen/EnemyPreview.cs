using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts.GamePlay.UI.StartScreen
{
    public class EnemyPreview : MonoBehaviour
    {
        private const string Multiplier = "X";
        
        [SerializeField] private Image _image;
        [SerializeField] private TextMeshProUGUI _counter;
        public void SetImage(Sprite sprite, int packCount)
        {
            _counter.text = Multiplier + packCount; 
            _image.sprite = sprite;
        }
    }
}
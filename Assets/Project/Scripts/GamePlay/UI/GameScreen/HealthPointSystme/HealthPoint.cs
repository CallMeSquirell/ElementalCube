using Framework.Extensions;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts.GamePlay.UI.GameScreen.HealthPointSystme
{
    public class HealthPoint : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private float _minAlpha = 0.5f;
        [SerializeField] private float _maxAlpha = 1f;
        
        public void SetState(bool isActive)
        {
            _image.color = _image.color.SetAlpha(isActive ? _maxAlpha : _minAlpha);
        }
    }
}
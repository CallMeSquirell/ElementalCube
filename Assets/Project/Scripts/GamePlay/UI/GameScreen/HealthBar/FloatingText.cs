using DG.Tweening;
using Framework.Extensions;
using Framework.Pool;
using TMPro;
using UnityEngine;

namespace Project.Scripts.GamePlay.UI.GameScreen.HealthBar
{
    [RequireComponent(typeof(RectTransform))]
    public class FloatingText : ObjectPoolItem
    {
        [Header("Values")]
        [SerializeField] private Vector2 _deltaPosition = new Vector2(0, 10);
        [SerializeField] private float _lifeTime = 1.5f;
        [SerializeField] private float _scaleUpTime = 0.85f;
        [SerializeField] private float _startFade = 0.3f;
        [SerializeField] private float _maxTextScale = 1.5f;
        
        [Header("References")]
        [SerializeField] private TextMeshProUGUI _text;

        private Vector2 _targetPosition;
        private RectTransform _rectTransform;
        private Sequence _sequence;

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
        }

        public void SetData(string value, Color color, float scale)
        {
            _text.transform.localScale = Vector3.one * Mathf.Clamp(1, _maxTextScale, scale);
            _text.color = color.SetAlpha(_startFade);
            _text.text = value;
        }

        public override void Release()
        {
            _sequence.Kill();
            base.Release();
        }

        public void Play(Vector3 transformPosition)
        {
            _rectTransform.position = transformPosition;
            var targetPosition = _rectTransform.anchoredPosition + _deltaPosition;
            var upTime = _lifeTime * _scaleUpTime;
            var downTime = _lifeTime - upTime;
            var downSequence = DOTween.Sequence()
                .Append(_text.DOFade(0, downTime))
                .Join(_rectTransform.DOAnchorPos(targetPosition, upTime));
            var upSequence = DOTween.Sequence()
                .Append(_rectTransform.DOAnchorPos(targetPosition, upTime))
                .Join(_text.DOFade(1, upTime));
            _sequence = DOTween.Sequence()
                .Append(upSequence)
                .Append(downSequence)
                .OnComplete(Release);
        }
    }
}
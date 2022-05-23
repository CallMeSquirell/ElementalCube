using System;
using System.Collections;
using System.Text;
using Framework.Extensions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace Project.Scripts.Util
{
    public class LoadingScreen : MonoBehaviour
    {
        private const string Dot = ".";
        
        [SerializeField] private Image _image;
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private string _baseString = "Loading";
        [SerializeField] private int _maxDotCount = 3;
        [SerializeField] private float _minAlpha = 0.5f;
        [SerializeField] private float _deltaAlpha = 0.1f;
        [SerializeField] private float _deltaTime = 0.1f;

        private float _imageAlpha = 0;
        private int _deltaAlphaMultiplier = 1;
        private int _currentDotCount = 0;
        private readonly StringBuilder _builder = new StringBuilder();

        private void Start()
        {
            StartCoroutine(AnimationCoroutine());
            DontDestroyOnLoad(this);
        }

        private void FixedUpdate()
        {
            _image.SetAlpha(Mathf.Lerp(_minAlpha, 1, _imageAlpha));
            RecalculateAlpha();
        }

        private IEnumerator AnimationCoroutine()
        {
            var waiter = new WaitForSeconds(_deltaTime);
            while (true)
            {
                RebuildString();
                _text.text = _builder.ToString();
                yield return waiter;
            }
        }

        private void RebuildString()
        {
            _builder.Clear();
            _builder.Append(_baseString);
            for (int i = 0; i < _currentDotCount; i++)
            {
                _builder.Append(Dot);
            }

            _currentDotCount++;
            if (_currentDotCount > _maxDotCount)
            {
                _currentDotCount = 0;
            }
        }

        private void RecalculateAlpha()
        {
            var newAlpha = _imageAlpha + _deltaAlpha * _deltaAlphaMultiplier;
            _imageAlpha = Mathf.Clamp(newAlpha, 0, 1);
            if (_imageAlpha >= 1 || _imageAlpha == 0)
            {
                _deltaAlphaMultiplier *= -1;
            }
        }
    }
}
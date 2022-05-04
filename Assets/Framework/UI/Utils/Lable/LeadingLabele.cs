using System;
using Framework.Extensions;
using Framework.Pool;
using UnityEngine;

namespace Framework.UI.Utils.Lable
{
    [RequireComponent(typeof(RectTransform))]
    public class LeadingLabele : ObjectPoolItem
    {
        [SerializeField] private Vector3 _offset = new Vector3(0,5, 0);
        private Transform _target;
        private RectTransform _transform;
        private Camera _camera;

        private void Awake()
        {
            _transform = GetComponent<RectTransform>();
            _camera = Camera.main;
        }

        public void SetUpTarget(Transform target)
        {
            _target = target;
        }

        private void Update()
        {
            if (_target.NonNull())
            {
                _transform.position = _camera.WorldToScreenPoint(_target.position) + _offset;
            }
        }
    }
}
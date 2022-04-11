using System;
using Project.Scripts.Input.Interfaces;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Project.Scripts.Input
{
    public class PlayerInputSystem : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
    {
        [SerializeField] private Camera _camera;

        private ITouchable _firstSelected;
        private ITouchable _currentSelected;

        private bool IsInAction => _firstSelected != null;

        public void OnPointerDown(PointerEventData eventData)
        {
            if (!IsInAction && CheckAndSetUp(eventData.position))
            {
                _firstSelected = _currentSelected;
                StartTouch();
            }
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (IsInAction)
            {
                if (_currentSelected != null && _currentSelected == _firstSelected)
                {
                    ProcessClick();
                }

                EndTouch();
            }

            Clear();
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (IsInAction)
            {
                CheckAndSetUp(eventData.position);
            }
        }

        private void StartTouch()
        {
            if (_currentSelected is ITouchStarted selected)
            {
                selected.OnTouchStarted();
            }
        }

        private void ProcessClick()
        {
            if (_currentSelected is IClickable selected)
            {
                selected.OnClicked();
            }
        }

        private void EndTouch()
        {
            if (_firstSelected is ITouchEnded selected)
            {
                selected.OnTouchEnded();
            }
        }

        private bool CheckAndSetUp(Vector2 position)
        {
            if (Physics.Raycast(_camera.ScreenPointToRay(position), out var hit) &&
                hit.transform.TryGetComponent(out _currentSelected))
            {
                return true;
            }

            _currentSelected = null;
            return false;
        }

        private void Clear()
        {
            _firstSelected = null;
            _currentSelected = null;
        }
    }
}
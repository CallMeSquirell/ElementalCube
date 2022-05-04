using Project.Scripts.Input.Interfaces;
using Project.Scripts.Input.Models;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Project.Scripts.Input
{
    public class InputSystem: MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
    {
        [SerializeField] private Camera _camera;
        
        private ITouchable _firstSelected;
        private ITouchable _currentSelected;

        private bool IsInAction => _firstSelected != null;
        
        private IInputStrategyProvider _inputStrategyProvider;

        [Inject]
        public void Initialize(IInputStrategyProvider inputStrategyProvider)
        {
            _inputStrategyProvider = inputStrategyProvider;
        }
        
        public void OnPointerDown(PointerEventData eventData)
        {
            if (!IsInAction && CheckAndSetUp(eventData.position))
            {
                _firstSelected = _currentSelected;
                _inputStrategyProvider.InputProcessor.TouchStarted(_currentSelected);
            }
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (IsInAction)
            {
                if (_currentSelected != null && _currentSelected == _firstSelected)
                {
                    _inputStrategyProvider.InputProcessor.Click(_currentSelected);
                }

                _inputStrategyProvider.InputProcessor.TouchEnded(_currentSelected);
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
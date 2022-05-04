using System;
using Framework.UI.MVP.DI;
using Framework.UI.MVP.DI.Provider;
using Framework.UI.MVP.Views.Core;
using Framework.UI.MVP.Views.Data;
using UnityEngine;
using Zenject;

namespace Framework.UI.Layer
{
    [RequireComponent(typeof(Canvas))]
    public class WindowLayer : MonoBehaviour
    {
        public event Action<WindowLayer> Cleared; 
        
        [SerializeField] private WindowLayerEnum _layerType;

        private Canvas _canvas;
        
        private IViewFactory _viewFactory;
        private IPresenterProvider _presenterProvider;
        
        private IViewData _placedViewData;
        private IViewData _viewToPlace;
        
        private ScreenBaseView _placedView;

        private bool _isFocused;
        private bool _isInprogress;
        private bool _isClosing;

        private Canvas Canvas => _canvas ? _canvas : _canvas = GetComponent<Canvas>();

        public int Order => Canvas.sortingOrder;

        public WindowLayerEnum LayerType => _layerType;

        public IViewData PlacedViewData => _placedViewData;

        public IScreenBaseView PlacedView => _placedView;

        [Inject]
        public void Construct(IViewFactory factory, IPresenterProvider presenterProvider)
        {
            _viewFactory = factory;
            _presenterProvider = presenterProvider;
        }

        public void PlaceView(IViewData data)
        {
            if (_isInprogress)
            {
                Debug.LogError($"Layer is busy with creating {_viewToPlace}");
                return;
            }
            
            _viewToPlace = data;
            
            if (_placedView != null)
            {
                if (!_isClosing)
                {
                    _isClosing = true;
                    _placedView.CloseView();
                }
            }
            else
            {
                OpenNextView();
            }
        }

        public void Clear()
        {
            if (_placedView != null && !_isClosing)
            {
                _viewToPlace = null;
                _isClosing = true;
                _placedView.CloseView(false);
            }
        }

        public void SetFocus(bool isInFocus)
        {
            _isFocused = isInFocus;
            if (_placedView != null)
            {
                _placedView.SetFocus(_isFocused);
            }
        }

        private void OpenNextView()
        {
            if (_viewToPlace != null)
            {
                _isInprogress = true;
                _viewFactory.Create<ScreenBaseView>(_viewToPlace.Definition, transform)
                    .Then(OnViewCreated)
                    .Fail(OnCreateFailed)
                    .Finally(() => _isInprogress = false);
            }
            else
            {
                Cleared?.Invoke(this);
            }
        }

        private void OnCreateFailed()
        {
            Debug.LogError("Failed to create view");
            _viewToPlace = null;
        }

        private void OnViewCreated(ScreenBaseView view)
        {
            if (_isClosing)
            {
                Destroy(view.gameObject);
                _isClosing = false;
                return;
            }
            
            _placedViewData = _viewToPlace;
            _viewToPlace = null;
            _placedView = view;
            _presenterProvider.ProvideTo(view, _placedViewData.Payload);
            _placedView.Opened += OnViewOpened;
            _placedView.Closed += OnViewClosed;
        }
        
        private void OnViewOpened()
        {
            _placedViewData.Listener.Opened.Dispatch();
        }

        private void OnViewClosed()
        {
            _placedView.Opened -= OnViewOpened;
            _placedView.Closed -= OnViewClosed;
            _presenterProvider.DisposePresenterFor(_placedView);
            Destroy(_placedView.gameObject);
            _placedViewData.Listener.Closed.Dispatch();
            _placedViewData = null;
            _placedView = null;
            _isClosing = false;
            OpenNextView();
        }
    }
}
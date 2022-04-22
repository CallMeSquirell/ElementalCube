using Project.Scripts.Framework.MVP.DI;
using Project.Scripts.Framework.MVP.Views;
using Project.Scripts.Framework.ResourceManagement;
using UnityEngine;
using Zenject;

namespace Project.Scripts.Framework.UI.Layer
{
    
    public class WindowLayer : MonoBehaviour
    {
        [SerializeField] private WindowLayerEnum _layerType;
        [SerializeField] private Canvas _canvas;

        private IViewFactory _viewFactory;
        
        private IManagedView _placedView;

        private IViewDefinition _viewToPlace;

        public int Order => _canvas.sortingOrder;

        public WindowLayerEnum LayerType => _layerType;

        public IManagedView PlacedView => _placedView;

        public IViewDefinition CurrentViewDefinition { get; private set; }

        private object _payload;
        
        [Inject]
        public void Construct(IViewFactory factory)
        {
            _viewFactory = factory;
        }
        
        public void PlaceView(IViewDefinition view, object payload = null)
        {
            _viewToPlace = view;
            _payload = payload;
            if (_placedView != null)
            {
                _placedView.CloseView();
            }
            else
            {
                OpenNextView();
            }
        }

        private void OpenNextView()
        {
            if (_viewToPlace != null)
            {
                CurrentViewDefinition = _viewToPlace;
                _placedView = _viewFactory.Create<IManagedView>(_viewToPlace, transform, _payload);
                _placedView.Closed += OnViewClosed;
            }
        }

        private void OnViewClosed(IManagedView view)
        {
            view.Closed -= OnViewClosed;
            CurrentViewDefinition = null;
            _placedView = null;
        }
    }
}
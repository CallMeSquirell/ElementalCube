using System;
using System.Collections.Generic;
using Project.Scripts.Framework.MVP.UI.Views;
using Zenject;

namespace Project.Scripts.Framework.MVP.DI.Binding
{
    public sealed class PresenterBinding : IPresenterBinding
    {
        private readonly IInstantiator _instantiator;
        private Type _presenterType;

        private readonly Dictionary<IWindowView, IPresenter> _createdPresenter 
            = new Dictionary<IWindowView, IPresenter>();

        public PresenterBinding(IInstantiator instantiator)
        {
            _instantiator = instantiator;
        }

        public void To<P>() where P : IPresenter<IWindowView>
        {
            _presenterType = typeof(P);
        }

        public void CreatePresenter(IWindowView windowView, object payload = null)
        {
            var args = payload != null ? new[] {windowView, payload} : new[] {windowView};
            var presenter = (IPresenter) _instantiator.Instantiate(_presenterType, args);
            presenter.Initialise();
            _createdPresenter.Add(windowView, presenter);
        }

        public void DestroyPresenter(IWindowView windowView)
        {
            var presenter = _createdPresenter[windowView];
            presenter.Dispose();
            _createdPresenter.Remove(windowView);
        }
    }
}
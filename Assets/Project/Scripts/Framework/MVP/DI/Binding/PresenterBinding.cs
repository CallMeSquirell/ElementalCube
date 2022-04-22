using System;
using System.Collections.Generic;
using Project.Scripts.Framework.MVP.Views;
using Zenject;

namespace Project.Scripts.Framework.MVP.DI.Binding
{
    public sealed class PresenterBinding : IPresenterBinding
    {
        private readonly IInstantiator _instantiator;
        private Type _presenterType;

        private readonly Dictionary<IManagedView, IPresenter> _createdPresenter 
            = new Dictionary<IManagedView, IPresenter>();

        public PresenterBinding(IInstantiator instantiator)
        {
            _instantiator = instantiator;
        }

        public void To<P>() where P : IPresenter<IManagedView>
        {
            _presenterType = typeof(P);
        }

        public void CreatePresenter(IManagedView managedView, object payload = null)
        {
            var args = payload != null ? new[] {managedView, payload} : new[] {managedView};
            var presenter = (IPresenter) _instantiator.Instantiate(_presenterType, args);
            presenter.Initialise();
            _createdPresenter.Add(managedView, presenter);
        }

        public void DestroyPresenter(IManagedView managedView)
        {
            var presenter = _createdPresenter[managedView];
            presenter.Dispose();
            _createdPresenter.Remove(managedView);
        }
    }
}
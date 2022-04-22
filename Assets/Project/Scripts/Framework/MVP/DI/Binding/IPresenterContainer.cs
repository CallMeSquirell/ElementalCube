using System;
using Project.Scripts.Framework.MVP.Views;

namespace Project.Scripts.Framework.MVP.DI.Binding
{
    public interface IPresenterContainer
    {
        IPresenterBinding BindView<T>() where T : ManagedView;
        IPresenterBinding GetBinding(Type type);
    }
}
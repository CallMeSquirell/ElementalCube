using System;
using Project.Scripts.Framework.MVP.UI.Views;

namespace Project.Scripts.Framework.MVP.DI.Binding
{
    public interface IPresenterContainer
    {
        IPresenterBinding BindView<T>() where T : WindowWindowView;
        IPresenterBinding GetBinding(Type type);
    }
}
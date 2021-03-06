using System;
using Framework.UI.MVP.Views.Core;

namespace Framework.UI.MVP.DI.Binding
{
    public interface IPresenterContainer
    {
        IPresenterBinding BindView<T>() where T : ScreenBaseView;
        IPresenterBinding GetBinding(Type type);
    }
}
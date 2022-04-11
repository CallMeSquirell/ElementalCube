using Project.Scripts.Framework.MVP.UI.Views;

namespace Project.Scripts.Framework.MVP.DI.Binding
{
    public interface IPresenterBinding
    {
        void To<P>() where P : IPresenter<IWindowView>;
        void CreatePresenter(IWindowView windowView, object payload = null);
        void DestroyPresenter(IWindowView windowView);
    }
}
using Project.Scripts.Framework.MVP.Views;

namespace Project.Scripts.Framework.MVP.DI.Binding
{
    public interface IPresenterBinding
    {
        void To<P>() where P : IPresenter<IManagedView>;
        void CreatePresenter(IManagedView managedView, object payload = null);
        void DestroyPresenter(IManagedView managedView);
    }
}
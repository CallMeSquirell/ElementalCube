using Project.Scripts.Framework.MVP.Views;

namespace Project.Scripts.Framework.MVP.DI.Provider
{
    public interface IPresenterProvider
    {
        void ProvideTo(IManagedView managedView, object payload = null);
        void ProvideIncludeSubViesTo(IManagedView managedView, object payload = null);
    }
}
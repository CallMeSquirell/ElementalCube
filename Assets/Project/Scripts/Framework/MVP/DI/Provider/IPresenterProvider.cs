using Project.Scripts.Framework.MVP.UI.Views;

namespace Project.Scripts.Framework.MVP.DI.Provider
{
    public interface IPresenterProvider
    {
        void ProvideTo(IWindowView windowView, object payload = null);
        void ProvideIncludeSubViesTo(IWindowView windowView, object payload = null);
    }
}
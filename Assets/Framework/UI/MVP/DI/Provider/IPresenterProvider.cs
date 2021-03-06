using Framework.UI.MVP.Views.Core;

namespace Framework.UI.MVP.DI.Provider
{
    public interface IPresenterProvider
    {
        void ProvideTo(IScreenBaseView screenBaseView, object payload);
        void DisposePresenterFor(IScreenBaseView screenBaseView);
    }
}
using Framework.UI.MVP.Views.Core;

namespace Framework.UI.MVP.DI.Binding
{
    public interface IPresenterBinding
    {
        void To<P>() where P : IPresenter<IScreenBaseView>;
        void CreatePresenter(IScreenBaseView screenBaseView, object payload = null);
        void DestroyPresenter(IScreenBaseView screenBaseView);
    }
}
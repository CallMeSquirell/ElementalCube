using System;

namespace Framework.UI.MVP.Views.Core
{
    public interface IPresenter : IDisposable
    {
        void Initialise();
    }

    public interface IPresenter<out T> : IPresenter where T : IScreenBaseView
    {
    }
}
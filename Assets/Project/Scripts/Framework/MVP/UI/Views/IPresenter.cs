using System;

namespace Project.Scripts.Framework.MVP.UI.Views
{
    public interface IPresenter : IDisposable
    {
        void Initialise();
    }

    public interface IPresenter<out T> : IPresenter where T : IWindowView
    {
    }
}
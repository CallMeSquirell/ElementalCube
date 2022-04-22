using System;

namespace Project.Scripts.Framework.MVP.Views
{
    public interface IPopUpView : IManagedView
    {
        event Action CloseClicked;
    }
}
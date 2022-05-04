using System;
using Framework.UI.MVP.Views.Core;

namespace Framework.UI.MVP.Views.PopUp
{
    public interface IPopUpView : IScreenBaseView
    {
        event Action CloseClicked;
    }
}
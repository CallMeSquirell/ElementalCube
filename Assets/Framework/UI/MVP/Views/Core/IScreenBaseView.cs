using System;

namespace Framework.UI.MVP.Views.Core
{
    public interface IScreenBaseView
    {
        event Action<bool> FocusChanged;
        event Action Opened;
        event Action Closed;
        bool Interactable { set; }
        bool IsFocused { get;}
        void CloseView(bool withAnimation = false);
    }
}
using System;
using Project.Scripts.Framework.Promises;

namespace Project.Scripts.Framework.MVP.Views
{
    public interface IManagedView
    {
        event Action<IManagedView> Closed;
        bool Interactable { set; }
        void CloseView();
    }
}
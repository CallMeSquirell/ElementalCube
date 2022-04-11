using Project.Scripts.Framework.Promises;

namespace Project.Scripts.Framework.MVP.UI.Views
{
    public interface IWindowView
    {
        bool Interactable { set; }
        void CloseView(); 
        IPromise Closed { get; }
    }
}
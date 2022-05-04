using Framework.Promises;

namespace Framework.UI.MVP.Views.ViewListeners
{
    public class ViewListener : IViewListener
    {
        public IPromise Opened { get; }
        public IPromise Closed { get; }
        
        public ViewListener()
        {
            Opened = new Promise();
            Closed = new Promise();
        }
    }
}
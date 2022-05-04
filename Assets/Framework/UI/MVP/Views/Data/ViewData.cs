using Framework.UI.MVP.Views.ViewListeners;

namespace Framework.UI.MVP.Views.Data
{
    public class ViewData : IViewData
    {
        public IViewDefinition Definition { get; }

        public IViewListener Listener { get; }
        public object Payload { get; }
        
        public ViewData(IViewDefinition definition,
            object payload = null)
        {
            Definition = definition;
            Listener = new ViewListener();
            Payload = payload;
        }
    }
}
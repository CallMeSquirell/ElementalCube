using Framework.UI.MVP.Views.ViewListeners;

namespace Framework.UI.MVP.Views.Data
{
    public interface IViewData
    {
        IViewDefinition Definition { get; }
        
        IViewListener Listener { get; }
        object Payload { get; }
    }
}
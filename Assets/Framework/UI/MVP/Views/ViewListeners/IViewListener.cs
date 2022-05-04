using Framework.Promises;

namespace Framework.UI.MVP.Views.ViewListeners
{
    public interface IViewListener
    {
        IPromise Opened { get; }
        IPromise Closed { get; }
    }
}
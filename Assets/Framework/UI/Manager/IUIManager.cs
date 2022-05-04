using Framework.UI.MVP.Views.Core;
using Framework.UI.MVP.Views.Data;
using Framework.UI.MVP.Views.ViewListeners;

namespace Framework.UI.Manager
{
    public interface IUIManager
    {
        IViewListener OpenView(IViewDefinition viewDefinition, object payload = null);
        IScreenBaseView GetView(IViewDefinition viewDefinition);
        void Initialise();
    }
}
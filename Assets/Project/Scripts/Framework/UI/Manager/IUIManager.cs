using Project.Scripts.Framework.MVP.Views;
using Project.Scripts.Framework.ResourceManagement;

namespace Project.Scripts.Framework.UI.Manager
{
    public interface IUIManager
    {
        void OpenView(IViewDefinition viewDefinition, object payload);
        IManagedView GetView(IViewDefinition viewDefinition);
    }
}
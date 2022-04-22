using Project.Scripts.Framework.MVP.Views;
using Project.Scripts.Framework.UI;
using Project.Scripts.Framework.UI.Layer;

namespace Project.Scripts.Framework.ResourceManagement
{
    public interface IViewDefinition
    {
        ManagedView Prefab { get; }
        WindowLayerEnum Layer { get; }
    }
}
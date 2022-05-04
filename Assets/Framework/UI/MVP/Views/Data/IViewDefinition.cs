using Framework.UI.Layer;

namespace Framework.UI.MVP.Views.Data
{
    public interface IViewDefinition
    {
        string ResourcePath { get; }
        string Name { get; }

        WindowLayerEnum LayerName { get; }
    }
}
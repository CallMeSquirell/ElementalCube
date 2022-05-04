using Framework.UI.Layer;
using Framework.UI.MVP.Views.Data;

namespace Project.Scripts.Framework.ResourceManagement
{
    public class RegisteredViews
    {
        //PopUp
        public static readonly IViewDefinition PlaceCubePopUp = new ViewDefinition("PlaceCubePopUp", WindowLayerEnum.PopUp, "Assets/Bundles/View_PlaceCubePopUp.prefab");
        
        //Screens
        public static readonly IViewDefinition GameScreen = new ViewDefinition("GameScreen", WindowLayerEnum.Game, "Assets/Project/Prefabs/GameScreen.prefab");
    }
}
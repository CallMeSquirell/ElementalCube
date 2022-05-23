using Framework.UI.Layer;
using Framework.UI.MVP.Views.Data;

namespace Project.Scripts.Constants
{
    public class RegisteredViews
    {
        //PopUp
        public static readonly IViewDefinition PlaceCubePopUp = new ViewDefinition("PlaceCubePopUp", WindowLayerEnum.PopUp, "Assets/Bundles/UI/PlaceCubePopUp/View_PlaceCubePopUp.prefab");
        public static readonly IViewDefinition RerollPopUp = new ViewDefinition("RerollPopUp", WindowLayerEnum.PopUp, "Assets/Bundles/UI/Reroll/RerolPopUP.prefab");
        
        //Screens
        public static readonly IViewDefinition GameScreen = new ViewDefinition("GameScreen", WindowLayerEnum.Game, "Assets/Bundles/UI/GameScreen/View_GameScreen.prefab");
        public static readonly IViewDefinition StartScreen = new ViewDefinition("StartScreen", WindowLayerEnum.Game, "Assets/Bundles/UI/StartScreen/View_StartScreen.prefab");
        public static readonly IViewDefinition ResultScreen = new ViewDefinition("ResultScreen", WindowLayerEnum.Game, "Assets/Bundles/UI/ResultScreen/View_ResultScreen.prefab");
    }
}
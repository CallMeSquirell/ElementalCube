using Framework.Pool;
using Project.Scripts.Configs;
using Project.Scripts.GamePlay.Cube.Data.Faces;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts.GamePlay.UI.PlaceTile.Views
{
    public class FaceInfoView : ObjectPoolItem
    {
        [SerializeField] private Image _image;
        
        public void SetInfo(ElementInfo elementInfo)
        {
            _image.enabled = elementInfo.Element != Element.Empty;
            _image.sprite = elementInfo.Sprite;
        }
    }
}
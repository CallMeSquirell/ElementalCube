using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Framework.UI.Utils
{
    public class ActionPanel : MonoBehaviour, IPointerClickHandler
    {
        public event Action Clicked; 

        public void OnPointerClick(PointerEventData eventData)
        {
            Clicked?.Invoke();
        }
    }
}
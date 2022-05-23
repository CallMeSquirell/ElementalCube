using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts.GamePlay.UI.GameScreen
{
    public class EnergyBarView : MonoBehaviour
    {
        [SerializeField] private Slider _slider;
        
        public void SetEnergyCount(int count)
        {
            _slider.value = count / 100.0f;
        }
    }
}
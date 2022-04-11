using Project.Scripts.Framework.MVP.DI.Provider;
using UnityEngine;
using Zenject;

namespace Project.Scripts.GameControl
{
    public class Level : MonoBehaviour
    {
        [Inject]
        private void Initialize(IPresenterProvider provider)
        {
            
        }
    }
}
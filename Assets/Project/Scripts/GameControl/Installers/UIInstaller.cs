using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Project.Scripts.GameControl.Installers
{
    public class UIInstaller : MonoInstaller
    {
        [SerializeField] 
        private List<MonoBehaviour> _listToInstall = new List<MonoBehaviour>();

        public override void InstallBindings()
        {
            foreach (var monoBehaviour in _listToInstall)
            {
                Container.Inject(monoBehaviour);
            }
        }
    }
}
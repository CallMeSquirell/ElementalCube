using Project.Scripts.Framework.UI.Manager;
using UnityEngine;
using Zenject;

namespace Project.Scripts.Framework.UI.Installer
{
    public class UIInstaller : MonoInstaller
    {
        [SerializeField] private UIManager _manager;
        
        public override void InstallBindings()
        {
            Container.Bind<IUIManager>().FromInstance(_manager).AsSingle();
        }
    }
}
using Framework.UI.Manager;
using Project.Scripts.Input.Models;
using UnityEngine;
using Zenject;

namespace Framework.UI.Installers
{
    public class UIInstaller : MonoInstaller
    {
        [SerializeField] private UIManager _manager;
        
        public override void InstallBindings()
        {
            Container.Bind<IUIManager>().FromInstance(_manager).AsSingle();
            Container.Bind<IInputStrategyProvider>().To<InputStrategyProvider>().AsSingle();
        }
    }
}
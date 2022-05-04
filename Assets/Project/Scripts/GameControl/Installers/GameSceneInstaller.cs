using UnityEngine;
using Zenject;

namespace Project.Scripts.GameControl.Installers
{
    public class GameSceneInstaller : MonoInstaller
    {
        [SerializeField] private Starter _starter;

        public override void InstallBindings()
        {
            
        }

        public override void Start()
        {
            Container.Inject(_starter);
            _starter.Initialize();
        }
    }
}
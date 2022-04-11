using Project.Scripts.GameControl.Loader;
using UnityEngine;
using Zenject;

namespace Project.Scripts.GameControl.Installers
{
    public class GameSceneInstaller : MonoInstaller
    {
        [SerializeField] private LevelLoader _levelLoader;

        public override void InstallBindings()
        {
            Container.Inject(_levelLoader);
        }
    }
}
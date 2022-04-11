using Project.Scripts.Framework.Factory;
using Project.Scripts.Framework.ResourceManagement;
using Project.Scripts.GamePlay.Cube.Configs;
using Project.Scripts.GamePlay.Cube.Views;
using UnityEngine;
using Zenject;

namespace Project.Scripts.GamePlay.Cube.Factory
{
    public class CubeFactory : BaseMonoBehaviourFactory<CubeView>, ICubeFactory
    {
        private readonly CubeConfig _viewConfig;
        
        public CubeFactory(IInstantiator instantiator, IConfig config) : base(instantiator)
        {
            _viewConfig = config.Get<CubeConfig>();
        }
        
        public CubeView Create(Transform parent)
        {
            return CreatePrefab(_viewConfig.Defenition, parent);
        }
        
        public override CubeView Create()
        {
            return CreatePrefab(_viewConfig.Defenition);
        }
    }
}
using Project.Scripts.Framework.MVP.UI.Views;
using UnityEngine;
using Zenject;

namespace Project.Scripts.Framework.Factory
{
    public abstract class BaseMonoBehaviourFactory<T> : IFactory<T>
    {
        private IInstantiator _instantiator;

        protected BaseMonoBehaviourFactory(IInstantiator instantiator)
        {
            _instantiator = instantiator;
        }
        
        protected T CreatePrefab(ViewDefinition defenition)
        {
            return _instantiator.InstantiatePrefabForComponent<T>(defenition.Prefab);
        }
        
        protected T CreatePrefab(ViewDefinition defenition, Transform parent)
        {
            return _instantiator.InstantiatePrefabForComponent<T>(defenition.Prefab, parent);
        }
        
        public abstract T Create();
    }
}
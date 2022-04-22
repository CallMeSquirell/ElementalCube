using System;
using System.Collections.Generic;
using Project.Scripts.Framework.MVVM;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts.Framework.UI.Utils
{
    public abstract class LayoutList<T,K> : BaseView<IEnumerable<K>> where T : LayoutListItem<K>
    {
        [SerializeField] private LayoutGroup _container;
        [SerializeField] private T _prefab;
        
        private LayoutListPool<T> _pool;
        private readonly List<T> _activeReferences = new List<T>();

        public List<T> ActiveReferences => _activeReferences;

        private void Awake()
        {
            _pool = new LayoutListPool<T>(Instantiator, _container.transform, _prefab);
        }

        public void Clear()
        {
            foreach (var reference in _activeReferences)
            {
                UnSubscribeFromItem(reference);
                reference.Release();
            }
            _activeReferences.Clear();
        }
        
        protected override void Initialize()
        {
            Clear();
            foreach (var dataItem in Data)
            {
                var reference  = _pool.Get();
                reference.SetData(dataItem);
                SubscribeOnItem(reference);
            }  
        }

        protected virtual void SubscribeOnItem(T item)
        {
            
        }
        
        protected virtual void UnSubscribeFromItem(T item)
        {
            
        }
    }
}
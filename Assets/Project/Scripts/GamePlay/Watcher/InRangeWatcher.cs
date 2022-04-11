using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Scripts.GamePlay.Watcher
{
    public class InRangeWatcher<T>
    {
        public event Action<T> Entered;
        public event Action<T> Left;
        
        private readonly LinkedList<T> _inRangeList = new LinkedList<T>();
        
        public LinkedList<T> InRangeList => _inRangeList;
        
        public void Enter(GameObject collider)
        {
            if (collider.TryGetComponent(out T component) &&
                !_inRangeList.Contains(component))
            {
                _inRangeList.AddLast(component);
                Entered?.Invoke(component);
            }
        }

        public void Exit(GameObject collider)
        {
            if (collider.TryGetComponent(out T component) &&
                _inRangeList.Contains(component))
            {
                _inRangeList.Remove(component);
                Entered?.Invoke(component);
            }
        }
    }
}
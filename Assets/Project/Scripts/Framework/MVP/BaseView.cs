using UnityEngine;

namespace Project.Scripts.Framework.MVP
{
    public abstract class BaseView<T> : MonoBehaviour
    {
        private T _data;

        public T Data => _data;
        
        public virtual void SetData(T data){}
    }
}
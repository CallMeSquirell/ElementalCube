using System;
using JetBrains.Annotations;

namespace Project.Scripts.Framework.BindableProperties
{
    public class BindableProperty<T> : IBindableProperty<T>
    {
        private event Action<T> Updated;
        private T _value;
        
        public T Value
        {
            get => _value;
            set
            {
                _value = value;
                Updated?.Invoke(_value);
            }
        }
        
        public BindableProperty(T value = default)
        {
            _value = value;
        }

        public void BindAndInvoke([NotNull]Action<T> method)
        {
            Updated += method;
            method.Invoke(_value);
        }

        public void Bind([NotNull]Action<T> method)
        {
            Updated += method;
        }

        public void UnBind([NotNull]Action<T> method)
        {
            Updated -= method;
        }

        public void ClearBindings()
        {
            Updated = null;
        }
    }
}
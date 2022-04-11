using System;

namespace Project.Scripts.Framework.BindableProperties
{
    public interface IBindableProperty<T>
    {
        T Value { get; }
        void Bind(Action<T> method);
        void BindAndInvoke(Action<T> method);
        void UnBind(Action<T> method);
        void ClearBindings();
    }
}
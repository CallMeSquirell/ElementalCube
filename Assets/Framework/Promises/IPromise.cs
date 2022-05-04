using System;

namespace Framework.Promises
{
    public interface IPromise
    {
        void Dispatch();
        void Abort();
        void SetProgress(float value);
        void BindTo(IPromise promise);
        IPromise Then(Action action);
        IPromise Fail(Action action);
        IPromise Progress(Action<float> action);
        IPromise Finally(Action action);
    }
    
    public interface IPromise<T> : IPromise
    {
        void Dispatch(T payload);
        IPromise<T> Then(Action<T> action);
    }
}
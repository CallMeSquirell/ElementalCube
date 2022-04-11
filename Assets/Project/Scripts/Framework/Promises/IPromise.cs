using System;

namespace Project.Scripts.Framework.Promises
{
    public interface IPromise
    {
        IPromise Then(Action action);
        IPromise Fail(Action action);
        IPromise Progress(Action action);
        IPromise Finally(Action action);
    }
}
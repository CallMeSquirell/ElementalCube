using System;

namespace Framework.Promises.Extensions
{
    public static class PromiseExtenstion
    {
        public static PromiseAction ToPromiseAction(this Func<IPromise> func)
        {
            return new PromiseAction(func);
        }
        
        public static PromiseAction ToPromiseAction(IPromise promise)
        {
            return new PromiseAction(promise);
        }
    }
}
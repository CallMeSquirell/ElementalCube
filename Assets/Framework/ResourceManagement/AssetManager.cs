using Framework.Promises;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Framework.ResourceManagement
{
    public class AssetManager : IAssetManager
    {
        public IPromise<T> LoadAsset<T>(string path)
        {
            var promise = new Promise<T>();
            
            var handler = Addressables.LoadAssetAsync<T>(path);
            var task = handler.Task.GetAwaiter();
            task.OnCompleted(() =>
            {
                if (handler.Status == AsyncOperationStatus.Succeeded)
                {
                    promise.Dispatch(task.GetResult());
                }
                else
                {
                    promise.Abort();     
                }
            });
            return promise;
        }

        public IPromise<T> LoadPrefabForComponent<T>(string path)
        {
            var result = new Promise<T>();
            var promise = LoadAsset<GameObject>(path);
            promise.Then(obj =>
            {
                if (obj.TryGetComponent(out T component))
                {
                    result.Dispatch(component);
                }
                else
                {
                    result.Abort();
                }
            }).Fail(result.Abort);
            result.BindTo(promise);
            return result;
        }
    }
}
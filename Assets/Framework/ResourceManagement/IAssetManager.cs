using Framework.Promises;

namespace Framework.ResourceManagement
{
    public interface IAssetManager
    {
        IPromise<T> LoadAsset<T>(string path);
        IPromise<T> LoadPrefabForComponent<T>(string path);
    }
}
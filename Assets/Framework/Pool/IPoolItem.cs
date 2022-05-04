namespace Framework.Pool
{
    public interface IPoolItem
    {
        bool IsFree { get; }
        void Load();
        void Retain();
        void Release();
    }
}
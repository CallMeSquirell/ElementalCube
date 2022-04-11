namespace Project.Scripts.Framework.Pool
{
    public interface IPool<T>
    {
        T Get();
        void Prepare(int count);
    }
}
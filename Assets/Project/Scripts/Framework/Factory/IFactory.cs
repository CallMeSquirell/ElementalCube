namespace Project.Scripts.Framework.Factory
{
    public interface IFactory<T>
    {
        T Create();
    }
}
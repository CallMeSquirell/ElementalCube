using Project.Scripts.Framework.Pool;

namespace Project.Scripts.Framework.UI.Utils
{
    public abstract class LayoutListItem<T> : ObjectPoolItem
    {
        private T _data;

        public T Data => _data;

        public virtual void SetData(T data)
        {
            _data = data;
        }
    }
}
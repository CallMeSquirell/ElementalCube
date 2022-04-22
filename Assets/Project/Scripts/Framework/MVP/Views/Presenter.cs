namespace Project.Scripts.Framework.MVP.Views
{
    public abstract class Presenter<V> : IPresenter<V> where V : IManagedView
    {
        protected V View { get; }

        public Presenter(V view)
        {
            View = view;
        }

        public virtual void Initialise()
        {
        }

        public virtual void Dispose()
        {
        }
    }
}
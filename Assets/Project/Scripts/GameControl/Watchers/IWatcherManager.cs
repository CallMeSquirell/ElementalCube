namespace Project.Scripts.GameControl.Watchers
{
    public interface IWatcherManager
    {
        void Register<T>() where T : IWatcher;
        void Deregister<T>() where T : IWatcher;
    }
}
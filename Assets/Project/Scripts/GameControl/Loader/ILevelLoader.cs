using Framework.Promises;

namespace Project.Scripts.GameControl.Loader
{
    public interface ILevelLoader
    {
        IPromise Load();
    }
}
using System;

namespace Project.Scripts.GameControl.Watchers
{
    public interface IWatcher : IDisposable
    {
        void Initialise();
    }
}
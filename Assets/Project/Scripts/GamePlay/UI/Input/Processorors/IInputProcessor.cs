using Project.Scripts.GamePlay.UI.Input.System;

namespace Project.Scripts.GamePlay.UI.Input.Processorors
{
    public interface IInputProcessor
    {
        void Click(ITouchable target);
        void TouchStarted(ITouchable target);
        void TouchEnded(ITouchable target);
    }
}
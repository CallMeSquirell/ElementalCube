using Project.Scripts.Input.Interfaces;

namespace Project.Scripts.Input.Processorors
{
    public interface IInputProcessor
    {
        void Click(ITouchable target);
        void TouchStarted(ITouchable target);
        void TouchEnded(ITouchable target);
    }
}
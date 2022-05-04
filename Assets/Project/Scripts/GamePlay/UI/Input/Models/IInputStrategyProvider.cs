using Project.Scripts.Input.Processorors;

namespace Project.Scripts.Input.Models
{
    public interface IInputStrategyProvider
    {
        IInputProcessor InputProcessor { get; }
    }
}
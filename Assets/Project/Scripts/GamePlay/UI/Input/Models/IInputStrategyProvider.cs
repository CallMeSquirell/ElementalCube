using Project.Scripts.GamePlay.UI.Input.Processorors;

namespace Project.Scripts.GamePlay.UI.Input.Models
{
    public interface IInputStrategyProvider
    {
        IInputProcessor InputProcessor { get; }
    }
}
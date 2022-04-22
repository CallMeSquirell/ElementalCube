using Project.Scripts.Input.Processorors;

namespace Project.Scripts.Input.Models
{
    public interface IInputData
    {
        IInputProcessor InputProcessor { get; }
    }
}
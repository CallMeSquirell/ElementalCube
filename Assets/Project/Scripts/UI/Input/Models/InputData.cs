using Project.Scripts.Input.Processorors;
using Project.Scripts.Input.Processorors.Impl;
using Zenject;

namespace Project.Scripts.Input.Models
{
    public class InputData : IInputData
    {
        public IInputProcessor InputProcessor { get; }
        
        public InputData(IInstantiator instantiator)
        {
            InputProcessor = instantiator.Instantiate<TileInputProcessor>();
        }
    }
}
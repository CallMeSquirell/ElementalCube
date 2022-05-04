using Project.Scripts.Input.Processorors;
using Project.Scripts.Input.Processorors.Impl;
using Zenject;

namespace Project.Scripts.Input.Models
{
    public class InputStrategyProvider : IInputStrategyProvider
    {
        public IInputProcessor InputProcessor { get; }
        
        public InputStrategyProvider(IInstantiator instantiator)
        {
            InputProcessor = instantiator.Instantiate<TileInputProcessor>();
        }
    }
}
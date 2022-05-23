using Project.Scripts.GamePlay.UI.Input.Processorors;
using Project.Scripts.GamePlay.UI.Input.Processorors.Impl;
using Zenject;

namespace Project.Scripts.GamePlay.UI.Input.Models
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
using Zenject;

namespace Framework.Commands
{
    public class CommandFactory : ICommandFactory
    {
        private readonly IInstantiator _instantiator;

        public CommandFactory(IInstantiator instantiator)
        {
            _instantiator = instantiator;
        }

        public ICommand Create(ICommandInfo binding)
        {
            return _instantiator.Instantiate(binding.BindedType) as ICommand;
        }
    }
}
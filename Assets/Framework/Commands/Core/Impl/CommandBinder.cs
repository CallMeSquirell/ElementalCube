using System;
using System.Collections.Generic;

namespace Framework.Commands
{
    internal class CommandBinder : ICommandBinder
    {
        private readonly Dictionary<Type, ICommandBinding> _bindings = new Dictionary<Type, ICommandBinding>();

        public ICommandBinding Bind<T>() where T : ICommand
        {
            var binding = new CommandBinding<T>();
            _bindings.Add(typeof(T), binding);
            return binding;
        }
        
        public bool TryGetBind<T>(out ICommandBinding result) where T : ICommand
        {
            if (_bindings.TryGetValue(typeof(T), out ICommandBinding binding))
            {
                result = binding;
                return true;
            }
            
            result = null;
            return false;
        }
        
        public void UnBind<T>() where T : ICommand
        {
            _bindings.Remove(typeof(T));
        }
    }
}
using Framework.Commands.ExecutableQueue;
using Zenject;

namespace Framework.Commands
{
    public class CommandInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.Bind<ICommandBinder>().To<CommandBinder>();
            Container.Bind<ICommandExecutor>().To<CommandExecutor>();
            Container.Bind<ICommandFactory>().To<CommandFactory>();
            Container.Bind<ICommandQueueFactory>().To<CommandQueueFactory>();
        }
    }
}
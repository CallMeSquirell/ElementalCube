namespace Framework.Commands
{
    public interface ICommandFactory
    {
        ICommand Create(ICommandInfo binding);
    }
}
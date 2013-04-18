namespace Momntz.Data.CommandHandlers
{
    public interface ICommandHandler<in TCommand> where TCommand : class
    {
        /// <summary> Handles. </summary>
        /// <param name="command"> The command. </param>
        void Execute(TCommand command);
    }
}

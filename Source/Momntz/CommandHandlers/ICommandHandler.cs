namespace Momntz.CommandHandlers
{
    public interface ICommandHandler<in TCommand> where TCommand : class
    {
        /// <summary> Handles. </summary>
        /// <param name="command"> The command. </param>
        void Handles(TCommand command);
    }
}

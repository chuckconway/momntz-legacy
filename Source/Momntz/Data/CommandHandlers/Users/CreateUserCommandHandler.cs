using Hypersonic;
using Momntz.Data.Commands.Users;

namespace Momntz.Data.CommandHandlers.Users
{
    public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand>
    {
        private readonly IMomntzSession _session;

        /// <summary> Constructor. </summary>
        /// <param name="session"> The session. </param>
        public CreateUserCommandHandler(IMomntzSession session)
        {
            _session = session;
        }

        /// <summary> Handles. </summary>
        /// <param name="command"> The command. </param>
        public void Execute(CreateUserCommand command)
        {
            _session.Session.Save(command, "User");
        }
    }
}

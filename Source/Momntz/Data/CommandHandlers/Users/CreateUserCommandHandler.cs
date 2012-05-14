using Hypersonic;
using Momntz.Data.Commands.Users;

namespace Momntz.Data.CommandHandlers.Users
{
    public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand>
    {
        private readonly ISession _session;

        /// <summary> Constructor. </summary>
        /// <param name="session"> The session. </param>
        public CreateUserCommandHandler(ISession session)
        {
            _session = session;
        }

        /// <summary> Handles. </summary>
        /// <param name="command"> The command. </param>
        public void Execute(CreateUserCommand command)
        {
            _session.Save(command, "User");
        }
    }
}

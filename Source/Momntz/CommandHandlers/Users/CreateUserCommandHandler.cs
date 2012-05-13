using Hypersonic;
using Hypersonic.Session;
using Momntz.Commands.Users;

namespace Momntz.CommandHandlers.Users
{
    public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand>
    {
        private readonly IDatabase _database;

        /// <summary> Constructor. </summary>
        /// <param name="database"> The database. </param>
        public CreateUserCommandHandler(IDatabase database)
        {
            _database = database;
        }

        /// <summary> Handles. </summary>
        /// <param name="command"> The command. </param>
        public void Handles(CreateUserCommand command)
        {
            using (ISession session = SessionFactory.SqlServer())
            {
                session.Save(command, "User");
            }
        }
    }
}

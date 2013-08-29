using ChuckConway.Cryptography;
using Momntz.Core.Extensions;
using Momntz.Data.Commands.Users;
using NHibernate;

namespace Momntz.Data.CommandHandlers.Users
{
    public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand>
    {
        private readonly ISession _session;
        private readonly ICrypto _crypto;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="session">The session.</param>
        /// <param name="crypto">The crypto.</param>
        public CreateUserCommandHandler(ISession session, ICrypto crypto)
        {
            _session = session;
            _crypto = crypto;
        }

        /// <summary> Handles. </summary>
        /// <param name="command"> The command. </param>
        public void Execute(CreateUserCommand command)
        {
            command.Password = _crypto.Hash(command.Password);

            using (var trans =_session.BeginTransaction())
            {
               _session.CreateCommandProcedure("User_Create", command)
                       .ExecuteUpdate();

                trans.Commit();
            }

        }
    }
}

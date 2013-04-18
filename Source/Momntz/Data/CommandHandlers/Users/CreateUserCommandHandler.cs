using System.Data;
using ChuckConway.Cryptography;
using Hypersonic;
using Momntz.Data.Commands.Users;

namespace Momntz.Data.CommandHandlers.Users
{
    public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand>
    {
        private readonly IDatabase _database;
        private readonly ICrypto _crypto;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="database">The database.</param>
        /// <param name="crypto">The crypto.</param>
        public CreateUserCommandHandler(IDatabase database, ICrypto crypto)
        {
            _database = database;
            _crypto = crypto;
        }

        /// <summary> Handles. </summary>
        /// <param name="command"> The command. </param>
        public void Execute(CreateUserCommand command)
        {
            command.Password = _crypto.Hash(command.Password);  

            _database.ConnectionStringName = "sql";
            _database.CommandType = CommandType.StoredProcedure;
            _database.NonQuery("User_Create", command);
        }
    }
}

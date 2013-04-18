using Hypersonic;
using Momntz.Data.Commands.Tags;

namespace Momntz.Data.CommandHandlers.Tags
{
    public class DeleteTagCommandHandler : ICommandHandler<DeleteTagCommand>
    {
        private readonly IDatabase _database;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteTagCommandHandler" /> class.
        /// </summary>
        /// <param name="database">The database.</param>
        public DeleteTagCommandHandler(IDatabase database)
        {
            _database = database;
        }

        /// <summary>
        /// Executes the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// 
        public void Execute(DeleteTagCommand command)
        {
            _database.NonQuery("TagPerson_Delete", command);
        }
    }
}

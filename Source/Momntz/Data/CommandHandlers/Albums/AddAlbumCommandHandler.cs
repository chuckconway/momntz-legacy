using Hypersonic;
using Momntz.Data.Commands.Albums;

namespace Momntz.Data.CommandHandlers.Albums
{
    public class AddAlbumCommandHandler : ICommandHandler<AddAlbumCommand>
    {
        private readonly IDatabase _database;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddAlbumCommandHandler" /> class.
        /// </summary>
        /// <param name="database">The database.</param>
        public AddAlbumCommandHandler(IDatabase database)
        {
            _database = database;
        }

        /// <summary>
        /// Executes the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        public void Execute(AddAlbumCommand command)
        {
            _database.NonQuery("TagAlbum_Add", command);
        }
    }
}

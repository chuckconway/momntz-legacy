using Hypersonic;
using Momntz.Data.Commands.Albums;

namespace Momntz.Data.CommandHandlers.Albums
{
    public class RemoveAlbumCommandHandler : ICommandHandler<RemoveAlbumCommand>
    {
        private readonly IDatabase _database;

        /// <summary>
        /// Initializes a new instance of the <see cref="RemoveAlbumCommandHandler" /> class.
        /// </summary>
        /// <param name="database">The database.</param>
        public RemoveAlbumCommandHandler(IDatabase database)
        {
            _database = database;
        }

        /// <summary>
        /// Executes the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        public void Execute(RemoveAlbumCommand command)
        {
            _database.NonQuery("TagAlbum_Remove", command);
        }
    }
}

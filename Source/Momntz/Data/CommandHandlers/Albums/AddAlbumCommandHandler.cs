using Momntz.Data.Commands.Albums;

namespace Momntz.Data.CommandHandlers.Albums
{
    public class AddAlbumCommandHandler : ICommandHandler<AddAlbumCommand>
    {
        private readonly IMomntzSession _session;

        public AddAlbumCommandHandler(IMomntzSession session)
        {
            _session = session;
        }

        public void Execute(AddAlbumCommand command)
        {
            _session.Session.Database.NonQuery("TagAlbum_Add", command);
        }
    }
}

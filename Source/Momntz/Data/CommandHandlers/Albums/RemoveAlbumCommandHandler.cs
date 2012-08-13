using Momntz.Data.Commands.Albums;

namespace Momntz.Data.CommandHandlers.Albums
{
    public class RemoveAlbumCommandHandler : ICommandHandler<RemoveAlbumCommand>
    {
        private readonly IMomntzSession _session;

        public RemoveAlbumCommandHandler(IMomntzSession session)
        {
            _session = session;
        }

        public void Execute(RemoveAlbumCommand command)
        {
            _session.Session.Database.NonQuery("TagAlbum_Remove", command);
        }
    }
}

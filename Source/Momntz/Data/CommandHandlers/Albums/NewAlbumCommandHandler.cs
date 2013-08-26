using System;
using Momntz.Data.Commands.Albums;
using Momntz.Data.Schema;
using NHibernate;

namespace Momntz.Data.CommandHandlers.Albums
{
    public class NewAlbumCommandHandler : ICommandHandler<NewAlbumCommand>
    {
        private readonly ISession _session;

        /// <summary>
        /// Initializes a new instance of the <see cref="NewAlbumCommandHandler"/> class.
        /// </summary>
        /// <param name="session">The session.</param>
        public NewAlbumCommandHandler(ISession session)
        {
            _session = session;
        }

        /// <summary>
        /// Executes the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        public void Execute(NewAlbumCommand command)
        {
            using (var trans = _session.BeginTransaction())
            {
                var album = new Album {Name = command.Name, Story = command.Story, Username = command.Username, CreateDate = DateTime.UtcNow};
                _session.Save(album);

                trans.Commit();
            }
        }
    }
}

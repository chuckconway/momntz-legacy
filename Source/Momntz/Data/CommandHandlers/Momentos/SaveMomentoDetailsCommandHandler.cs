using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Momntz.Data.Commands.Momentos;
using Momntz.Model;

namespace Momntz.Data.CommandHandlers.Momentos
{
    public class SaveMomentoDetailsCommandHandler : ICommandHandler<SaveMomentoDetailsCommand>
    {
        private readonly IMomntzSession _session;

        public SaveMomentoDetailsCommandHandler(IMomntzSession session )
        {
            _session = session;
        }

        public void Execute(SaveMomentoDetailsCommand command)
        {
            _session.Session.Database.NonQuery("Momento_SaveDetails", new { command.Day,  command.Id, command.Location, command.Month, command.Story, command.Title, command.Year });

            TagCollection collection = new TagCollection(command.Albums);

            foreach (Tag s in collection)
            {
                _session.Session.Database.NonQuery("TagAlbum_AddMomento", new {command.Username, MomentoId = command.Id, AlbumName = s.Name});
            }
        }
    }
}

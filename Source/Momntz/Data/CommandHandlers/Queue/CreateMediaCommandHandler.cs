using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Hypersonic;
using Momntz.Data.Commands.Queue;
using Momntz.Model.Configuration;

namespace Momntz.Data.CommandHandlers.Queue
{
    public class CreateMediaCommandHandler : ICommandHandler<CreateMediaCommand>
    {
        private readonly IMomntzQueueSession _session;
        private readonly ISettings _settings;

        public CreateMediaCommandHandler(IMomntzQueueSession session, ISettings settings)
        {
            _session = session;
            _settings = settings;
        }

        public void Execute(CreateMediaCommand command)
        {
                var parameters = new List<DbParameter>()
                                     {
                                         _session.Session.Database.MakeParameter("@Id", command.Id),
                                         _session.Session.Database.MakeParameter("@Filename", command.Filename),
                                         _session.Session.Database.MakeParameter("@Extension", command.Extension),
                                         _session.Session.Database.MakeParameter("@Size", command.Size),
                                         _session.Session.Database.MakeParameter("@Username", command.Username),
                                         _session.Session.Database.MakeParameter("@ContentType", command.ContentType),
                                         _session.Session.Database.MakeParameter("@MediaType", command.MediaType),
                                         _session.Session.Database.MakeParameter("@Bytes", DbType.Binary, command.Bytes.Length, command.Bytes)
                                     };

                _session.Session.Database.CommandType = CommandType.Text;
                _session.Session.Database.NonQuery("Insert Into Media(Id, Extension, Filename, Size, Username, ContentType, MediaType, Bytes) Values (@Id, @Extension, @Filename, @Size, @Username, @ContentType, @MediaType, @Bytes)", parameters);
        }
    }
}

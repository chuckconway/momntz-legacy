using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Hypersonic;
using Momntz.Data.Commands.Queue;

namespace Momntz.Data.CommandHandlers.Queue
{
    public class CreateMediaCommandHandler : ICommandHandler<CreateMediaCommand>
    {
        private readonly ISession _session;

        public CreateMediaCommandHandler(ISession session)
        {
            _session = session;
        }

        public void Execute(CreateMediaCommand command)
        {
            try
            {
                var parameters = new List<DbParameter>()
                                     {
                                         _session.Database.MakeParameter("@Id", command.Id),
                                         _session.Database.MakeParameter("@Filename", command.Filename),
                                         _session.Database.MakeParameter("@Extension", command.Extension),
                                         _session.Database.MakeParameter("@Size", command.Size),
                                         _session.Database.MakeParameter("@Username", command.Username),
                                         _session.Database.MakeParameter("@ContentType", command.ContentType),
                                         _session.Database.MakeParameter("@MediaType", command.MediaType),
                                         _session.Database.MakeParameter("@Bytes", DbType.Binary, command.Bytes.Length, command.Bytes)
                                     };

                _session.Database.ConnectionStringName = "queue";
                _session.Database.CommandType = CommandType.Text;

                _session.Database.NonQuery("Insert Into Media(Id, Extension, Filename, Size, Username, ContentType, MediaType, Bytes) Values (@Id, @Extension, @Filename, @Size, @Username, @ContentType, @MediaType, @Bytes)", parameters);
            }
            finally
            {
                _session.Database.ConnectionStringName = null;
            }
        }
    }
}

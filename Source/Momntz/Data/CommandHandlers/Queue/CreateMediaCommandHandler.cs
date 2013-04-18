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
        private readonly IDatabase _database;
        private readonly ISettings _settings;

        public CreateMediaCommandHandler(IDatabase database, ISettings settings)
        {
            _database = database;
            _settings = settings;
        }

        public void Execute(CreateMediaCommand command)
        {
                var parameters = new List<DbParameter>()
                                     {
                                         _database.MakeParameter("@Id", command.Id),
                                         _database.MakeParameter("@Filename", command.Filename),
                                         _database.MakeParameter("@Extension", command.Extension),
                                         _database.MakeParameter("@Size", command.Size),
                                         _database.MakeParameter("@Username", command.Username),
                                         _database.MakeParameter("@MediaType", command.MediaType),
                                         _database.MakeParameter("@Bytes", DbType.Binary, command.Bytes.Length, command.Bytes)
                                     };

                _database.CommandType = CommandType.Text;
                _database.ConnectionString = _settings.QueueDatabase;
                _database.NonQuery("Insert Into Media(Id, Extension, Filename, Size, Username, MediaType, Bytes) Values (@Id, @Extension, @Filename, @Size, @Username, @MediaType, @Bytes)", parameters);
        }
    }
}

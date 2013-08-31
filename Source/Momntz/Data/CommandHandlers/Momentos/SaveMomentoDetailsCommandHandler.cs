using Hypersonic;
using Momntz.Data.Commands.Momentos;

namespace Momntz.Data.CommandHandlers.Momentos
{
    public class SaveMomentoDetailsCommandHandler : ICommandHandler<SaveMomentoDetailsCommand>
    {
        private readonly IDatabase _database;

        public SaveMomentoDetailsCommandHandler(IDatabase database )
        {
            _database = database;
        }

        public void Execute(SaveMomentoDetailsCommand parameters)
        {
            _database.ConnectionStringName = "sql";
            _database.NonQuery("Momento_SaveDetails", new { parameters.Day, parameters.Id, parameters.Location, parameters.Month, parameters.Story, parameters.Title, parameters.Year });
        }
    }
}

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

        public void Execute(SaveMomentoDetailsCommand command)
        {
            _database.ConnectionStringName = "sql";
            _database.NonQuery("Momento_SaveDetails", new { command.Day, command.Id, command.Location, command.Month, command.Story, command.Title, command.Year });
        }
    }
}

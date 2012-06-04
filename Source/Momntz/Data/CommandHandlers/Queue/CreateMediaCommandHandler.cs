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
            _session.Database.ConnectionStringName = "queue";
            _session.Save(command, "Media");

        }
    }
}

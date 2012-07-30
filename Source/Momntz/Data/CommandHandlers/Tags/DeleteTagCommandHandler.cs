using Momntz.Data.Commands.Tags;

namespace Momntz.Data.CommandHandlers.Tags
{
    public class DeleteTagCommandHandler : ICommandHandler<DeleteTagCommand>
    {
        private readonly IMomntzSession _session;

        public DeleteTagCommandHandler(IMomntzSession session)
        {
            _session = session;
        }

        public void Execute(DeleteTagCommand command)
        {
            _session.Session.Database.NonQuery("TagPerson_Delete", command);
        }
    }
}

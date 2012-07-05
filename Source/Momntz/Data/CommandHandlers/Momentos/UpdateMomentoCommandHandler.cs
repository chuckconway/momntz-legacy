using Momntz.Data.Commands.Momentos;
using Momntz.Model;

namespace Momntz.Data.CommandHandlers.Momentos
{
    public class UpdateMomentoCommandHandler : ICommandHandler<UpdateMomentoCommand>
    {
        private readonly IMomntzSession _session;

        public UpdateMomentoCommandHandler(IMomntzSession session)
        {
            _session = session;
        }

        public void Execute(UpdateMomentoCommand command)
        {
            _session.Session.SaveAnonymous<Momento>(new {command.Title, command.Story, command.Day, command.Month, command.Year}, "Momento", (m)=> m.Id == command.Id);
        }
    }
}

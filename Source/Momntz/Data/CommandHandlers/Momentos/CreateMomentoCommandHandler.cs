using System;
using System.Collections;
using Momntz.Data.Commands.Momentos;
using Momntz.Model;

namespace Momntz.Data.CommandHandlers.Momentos
{
    public class CreateMomentoCommandHandler : ICommandHandler<CreateMomentoCommand>
    {
        private readonly IMomntzSession _session;

        public CreateMomentoCommandHandler(IMomntzSession session)
        {
            _session = session;
        }

        public void Execute(CreateMomentoCommand command)
        {
            var single = SaveMomento(command);
            SaveMedia(command, single);
        }

        private void SaveMedia(CreateMomentoCommand command, Momento single)
        {
            command.Media.ForEach(m => m.MomentoId = single.Id);
            _session.Session.Save((ICollection)command.Media, "MomentoMedia");
        }

        private Momento SaveMomento(CreateMomentoCommand command)
        {
            Guid internalId = Guid.NewGuid();
            _session.Session.Save(new { command, internalId, UploadedBy = command.Username }, "Momento");

            var single = _session.Session.Query<Momento>()
                .Where(m => m.InternalId == internalId)
                .Single();

            return single;
        }
    }
}

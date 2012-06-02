using System;
using System.Collections;
using Hypersonic;
using Momntz.Data.Commands.Momentos;
using Momntz.Model;

namespace Momntz.Data.CommandHandlers.Momentos
{
    public class CreateMomentoCommandHandler : ICommandHandler<CreateMomentoCommand>
    {
        private readonly ISession _session;

        public CreateMomentoCommandHandler(ISession session)
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
            _session.Save((ICollection)command.Media, "MomentoMedia");
        }

        private Momento SaveMomento(CreateMomentoCommand command)
        {
            Guid internalId = Guid.NewGuid();
            _session.Save(new { command, internalId, UploadedBy = command.Username}, "Momento");

            var single = _session.Query<Momento>()
                .Where(m => m.InternalId == internalId)
                .Single();

            return single;
        }
    }
}

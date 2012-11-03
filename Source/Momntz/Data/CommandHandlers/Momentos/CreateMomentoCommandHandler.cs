using System;
using Momntz.Data.Commands.Momentos;
using Momntz.Infrastructure;
using Momntz.Model;
using NHibernate;
using Mapper = AutoMapper.Mapper;

namespace Momntz.Data.CommandHandlers.Momentos
{
    public class CreateMomentoCommandHandler : ICommandHandler<CreateMomentoCommand>
    {

        private readonly ISession _session;
        private readonly IMap _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateMomentoCommandHandler" /> class.
        /// </summary>
        /// <param name="session">The session.</param>
        /// <param name="mapper">The mapper.</param>
        public CreateMomentoCommandHandler(ISession session, IMap mapper)
        {
            _session = session;
            _mapper = mapper;
        }

        /// <summary>
        /// Executes the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        public void Execute(CreateMomentoCommand command)
        {
            var single = SaveMomento(command);
            SaveMedia(command, single);
        }

        /// <summary>
        /// Saves the media.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="single">The single.</param>
        private void SaveMedia(CreateMomentoCommand command, Momento single)
        {
            command.Media.ForEach(m => m.MomentoId = single.Id);
            var media = command.Media.ConvertAll(Mapper.DynamicMap<CreateMomentoMediaCommand, MomentoMedia>);

                using(var transaction = _session.BeginTransaction())
                {
                    foreach (var momentoMedia in media)
                    {
                        momentoMedia.Momento = single;
                        _session.Save(momentoMedia);
                    }

                    transaction.Commit();
            }
        }

        /// <summary>
        /// Saves the momento.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>Momento.</returns>
        private Momento SaveMomento(CreateMomentoCommand command)
        {
            var momento = _mapper.Map<CreateMomentoCommand, Momento>(command);

            momento.UploadedBy = command.Username; 
            momento.InternalId = Guid.NewGuid();
            momento.Visibility = MomentoVisibility.Public;

            using (var trans = _session.BeginTransaction())
            {
                _session.Save(momento);
                _session.Save(new MomentoUser {Momento = momento, Username = command.Username});

                trans.Commit();
            }

            return momento;

            //Guid internalId = Guid.NewGuid();
            //_session.Session.Save(new { command, internalId, UploadedBy = command.Username }, "Momento");

            //var single = _session.Session.Query<Momento>()
            //    .Where(m => m.InternalId == internalId)
            //    .Single();

            //return single;
        }
    }
}

using System;
using AutoMapper;
using Momntz.Data.Commands.Momentos;
using Momntz.Model;
using NHibernate;

namespace Momntz.Data.CommandHandlers.Momentos
{
    public class CreateMomentoCommandHandler : ICommandHandler<CreateMomentoCommand>
    {
        private readonly ISessionFactory _sessionFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateMomentoCommandHandler" /> class.
        /// </summary>
        /// <param name="sessionFactory">The session factory.</param>
        public CreateMomentoCommandHandler(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
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

            using (ISession session = _sessionFactory.OpenSession())
            {
                session.Save(command.Media);
            }

            //_session.Session.Save((ICollection)command.Media, "MomentoMedia");
        }

        /// <summary>
        /// Saves the momento.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>Momento.</returns>
        private Momento SaveMomento(CreateMomentoCommand command)
        {
            var momento = Mapper.DynamicMap<Momento>(command);
            momento.UploadedBy = command.Username; 
            momento.InternalId = Guid.NewGuid();

            using (ISession session = _sessionFactory.OpenSession())
            {
                session.Save(momento);
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

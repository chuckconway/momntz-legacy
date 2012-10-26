using System;
using Momntz.Data.Commands.Momentos;
using Momntz.Model;
using NHibernate;

namespace Momntz.Data.CommandHandlers.Momentos
{
    public class UpdateMomentoCommandHandler : ICommandHandler<UpdateMomentoCommand>
    {
        private readonly ISessionFactory _sessionFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateMomentoCommandHandler" /> class.
        /// </summary>
        /// <param name="sessionFactory">The session factory.</param>
        public UpdateMomentoCommandHandler(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        /// <summary>
        /// Executes the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        public void Execute(UpdateMomentoCommand command)
        {
            Func<string, int?> nullable = s => (string.IsNullOrEmpty(command.Day) ? null : (int?)Convert.ToInt32(command.Day));

            using (ISession session = _sessionFactory.OpenSession())
            {
                var momento = session.Get<Momento>(command.Id);
                momento.Title = command.Title;
                momento.Story = command.Story;
                momento.Day = nullable(command.Day);
                momento.Month = nullable(command.Month);
                momento.Year = nullable(command.Year); //(string.IsNullOrEmpty(command.Day) ? null : (int?)Convert.ToInt32(command.Day));

                session.Save(momento);
            }

            //_session.Session.SaveAnonymous<Momento>(new {command.Title, command.Story, command.Day, command.Month, command.Year}, "Momento", (m)=> m.Id == command.Id);
        }
    }
}

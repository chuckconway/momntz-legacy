using System;
using Momntz.Data.Commands.Momentos;
using Momntz.Data.Schema;

using NHibernate;

namespace Momntz.Data.CommandHandlers.Momentos
{
    public class UpdateMomentoCommandHandler : ICommandHandler<UpdateMomentoCommand>
    {
        private readonly ISession _session;

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateMomentoCommandHandler" /> class.
        /// </summary>
        /// <param name="session">The session.</param>
        public UpdateMomentoCommandHandler(ISession session)
        {
            _session = session;
        }

        /// <summary>
        /// Executes the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        public void Execute(UpdateMomentoCommand command)
        {
            Func<string, int?> nullable = s => (string.IsNullOrEmpty(command.Day) ? null : (int?)Convert.ToInt32(command.Day));

            using (var trans = _session.BeginTransaction())
            {
                var momento = _session.Get<Momento>(command.Id);
                momento.Title = command.Title;
                momento.Story = command.Story;
                momento.Day = nullable(command.Day);
                momento.Month = nullable(command.Month);
                momento.Year = nullable(command.Year); //(string.IsNullOrEmpty(command.Day) ? null : (int?)Convert.ToInt32(command.Day));

                _session.Save(momento);
                trans.Commit();
            }

            //_session.Session.SaveAnonymous<Momento>(new {command.Title, command.Story, command.Day, command.Month, command.Year}, "Momento", (m)=> m.Id == command.Id);
        }
    }
}

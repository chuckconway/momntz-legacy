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
        /// <param name="parameters">The command.</param>
        public void Execute(UpdateMomentoCommand parameters)
        {
            Func<string, int?> nullable = s => (string.IsNullOrEmpty(parameters.Day) ? null : (int?)Convert.ToInt32(parameters.Day));

            using (var trans = _session.BeginTransaction())
            {
                var momento = _session.Get<Momento>(parameters.Id);
                momento.Title = parameters.Title;
                momento.Story = parameters.Story;
                momento.Day = nullable(parameters.Day);
                momento.Month = nullable(parameters.Month);
                momento.Year = nullable(parameters.Year); //(string.IsNullOrEmpty(command.Day) ? null : (int?)Convert.ToInt32(command.Day));

                _session.Save(momento);
                trans.Commit();
            }

            //_session.Session.SaveAnonymous<Momento>(new {command.Title, command.Story, command.Day, command.Month, command.Year}, "Momento", (m)=> m.Id == command.Id);
        }
    }
}

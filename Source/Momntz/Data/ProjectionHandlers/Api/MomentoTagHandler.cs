using System.Collections.Generic;
using System.Linq;
using Momntz.Data.Projections.Api;
using Momntz.Model;
using NHibernate;

namespace Momntz.Data.ProjectionHandlers.Api
{
    public class MomentoPersonHandler : IProjectionHandler<int, IList<MomentoPerson>>
    {
        private readonly ISession _session;
   

        /// <summary>
        /// Initializes a new instance of the <see cref="MomentoTagHandler" /> class.
        /// </summary>
        /// <param name="session">The session.</param>
        public MomentoPersonHandler(ISession session)
        {
            _session = session;
        }

        /// <summary>
        /// Executes the specified args.
        /// </summary>
        /// <param name="args">The args.</param>
        /// <returns>IList{MomentoPerson}.</returns>
        public IList<MomentoPerson> Execute(int args)
        {
            using (var  trans = _session.BeginTransaction())
            {
               var items = _session.QueryOver<Person>()
                        .Where(p => p.Momento.Id == args)
                        .List();


                trans.Commit();

                return items.Select(
                        i => new MomentoPerson()
                            {
                                MomentoId = i.Momento.Id,
                                Id = i.Id,
                                CreatedBy = i.CreatedBy,
                                DisplayName = i.Name,
                                Height = i.Height,
                                Username = i.Username,
                                Width = i.Width,
                                XAxis = i.XAxis,
                                YAxis = i.YAxis
                            }).ToList();
            }
        }
    }
}

using System.Collections.Generic;
using Hypersonic;
using Momntz.Data.Projections.Api;

namespace Momntz.Data.ProjectionHandlers.Api
{
    public class MomentoTagHandler : IProjectionHandler<int, IList<MomentoTag>>
    {
        private readonly IDatabase _database;


        /// <summary>
        /// Initializes a new instance of the <see cref="MomentoTagHandler" /> class.
        /// </summary>
        /// <param name="database">The database.</param>
        public MomentoTagHandler(IDatabase database)
        {
            _database = database;
        }

        /// <summary>
        /// Executes the specified args.
        /// </summary>
        /// <param name="args">The args.</param>
        /// <returns>IList{MomentoTag}.</returns>
        public IList<MomentoTag> Execute(int args)
        {
            return _database.List<MomentoTag, object>("TagPerson_RetrieveTagsByMomentoId", new { MomentoId = args });
        }
    }
}

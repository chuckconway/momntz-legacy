using System.Collections.Generic;
using System.Linq;
using Hypersonic;
using Momntz.Data.ProjectionHandlers.Momentos;
using Momntz.Data.Projections.Momentos;
using Momntz.Model;
using Momntz.Model.Configuration;

namespace Momntz.Data.ProjectionHandlers.Users
{
    public class GetMomentoByIdHandler : BaseMomentoHandler, IProjectionHandler<int, MomentoWithMedia>
    {
        private readonly IDatabase _database;

        public GetMomentoByIdHandler(IDatabase database, ISettings settings)
            : base(database, settings)
        {
            _database = database;
        }

        /// <summary>
        /// Executes the specified args.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>MomentoWithMedia.</returns>
        public MomentoWithMedia Execute(int id)
        {
            var media = new List<MomentoWithMedia>();
            var momento = _database.List<Momento, object>("[dbo].[Momento_RetrieveById]", new{id});

            GetMedia(momento, media);

            return media.SingleOrDefault();
        }
    }
}

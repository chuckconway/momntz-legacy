using System.Collections.Generic;
using Hypersonic;
using Momntz.Data.Projections.Momentos;
using Momntz.Model;
using Momntz.Model.Configuration;

namespace Momntz.Data.ProjectionHandlers.Momentos
{
    public class UserPageMomentosHandler : BaseMomentoHandler, IProjectionHandler<string, List<MomentoWithMedia>>
    {
        private readonly IDatabase _database;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserPageMomentosHandler" /> class.
        /// </summary>
        /// <param name="database">The database.</param>
        /// <param name="settings">The settings.</param>
        public UserPageMomentosHandler(IDatabase database, ISettings settings) : base(database, settings)
        {
            _database = database;
        }

        /// <summary>
        /// Executes the specified username.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns>List{MomentoWithMedia}.</returns>
        public List<MomentoWithMedia> Execute(string username)
        {
            var homepages = new List<MomentoWithMedia>();

            var momentos = _database
                    .List<Momento, object>("[dbo].[Momento_RetrieveRandom20ByUser]", new { username });
                GetMedia(momentos, homepages);

            return homepages;
        }
    }
}

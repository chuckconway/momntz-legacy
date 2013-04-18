using System.Collections.Generic;
using System.Linq;
using Hypersonic;
using Momntz.Data.Projections.Api;

namespace Momntz.Data.ProjectionHandlers.Api
{
    public class AlbumNameSearchHandler : IProjectionHandler<AlbumNameSearchParameters, List<AlbumNameResult>>
    {
        private readonly IDatabase _database;

        /// <summary>
        /// Initializes a new instance of the <see cref="AlbumNameSearchHandler" /> class.
        /// </summary>
        /// <param name="database">The database.</param>
        public AlbumNameSearchHandler(IDatabase database)
        {
            _database = database;
        }

        /// <summary>
        /// Executes the specified args.
        /// </summary>
        /// <param name="args">The args.</param>
        /// <returns>List{AlbumNameResult}.</returns>
        public List<AlbumNameResult> Execute(AlbumNameSearchParameters args)
        {
            return _database
                .List<AlbumNameResult, object>("TagAlbum_GetTermByFirstCharactersAndUsername", new { term = args.Term, username = args.Username })
                .ToList();

        }
    }

    public class AlbumNameSearchParameters
    {
        /// <summary>
        /// Gets or sets the term.
        /// </summary>
        /// <value>The term.</value>
        public string Term { get; set; }

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>The username.</value>
        public string Username { get; set; }
    }
}

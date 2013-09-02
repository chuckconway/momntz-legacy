using System.Collections.Generic;
using System.Linq;
using Hypersonic;
using Momntz.Data.Projections.Api;
using Momntz.Data.Repositories.Search.Parameters;
using Momntz.Data.Schema;

namespace Momntz.Data.Repositories.Search
{
    public interface ISearchRepository
    {
        /// <summary>
        /// Searches for the username.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns>List{NameSearchResult}.</returns>
        List<NameSearchResult> SearchUsername(NameAndUsername args);
    }

    public class SearchRepository : ISearchRepository
    {
        private readonly IDatabase _database;

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchRepository"/> class.
        /// </summary>
        /// <param name="database">The database.</param>
        public SearchRepository(IDatabase database)
        {
            _database = database;
        }


        /// <summary>
        /// Searches for the username.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns>List{NameSearchResult}.</returns>
        public List<NameSearchResult> SearchUsername(NameAndUsername args)
        {
            var items = _database.List<Name, object>("AlsoKnownAs_FindNameByFirstLetersAndUsername", new { Search = args.Name, args.Username }).ToList();
            return items.ConvertAll(a => new NameSearchResult { id = a.AlsoKnownAsId, label = a.FullName, value = a.FullName });
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using Hypersonic;
using Momntz.Data.Projections.Api;
using Momntz.Data.Schema;


namespace Momntz.Data.ProjectionHandlers.Api
{
    public class NameSearchByUsernameHandler : IProjectionHandler<NameAndUsername, List<NameSearchResult>>
    {
        private readonly IDatabase _database;

        /// <summary>
        /// Initializes a new instance of the <see cref="NameSearchByUsernameHandler" /> class.
        /// </summary>
        /// <param name="database">The database.</param>
        public NameSearchByUsernameHandler(IDatabase database)
        {
            _database = database;
        }

        /// <summary>
        /// Executes the specified args.
        /// </summary>
        /// <param name="args">The args.</param>
        /// <returns>List{NameSearchResult}.</returns>
        public List<NameSearchResult> Execute(NameAndUsername args)
        {
            var items = _database.List<Name, object>("AlsoKnownAs_FindNameByFirstLetersAndUsername", new { Search = args.Name, args.Username }).ToList();
                return items.ConvertAll(a => new NameSearchResult { id = a.AlsoKnownAsId, label = a.FullName, value = a.FullName });
        }
    }

    public class NameAndUsername
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>The username.</value>
        public string Username { get; set; }
    }
}

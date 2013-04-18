using System.Collections.Generic;
using System.Linq;
using Hypersonic;
using Momntz.Data.Projections.Momentos;

namespace Momntz.Data.ProjectionHandlers.Momentos
{
    public class LocationAutoCompleteHandler : IProjectionHandler<LocationAutoCompleteParameters, List<LocationAutoComplete>>
    {
        private readonly IDatabase _database;

        /// <summary>
        /// Initializes a new instance of the <see cref="LocationAutoCompleteHandler" /> class.
        /// </summary>
        /// <param name="database">The database.</param>
        public LocationAutoCompleteHandler(IDatabase database)
        {
            _database = database;

        }

        /// <summary>
        /// Executes the specified args.
        /// </summary>
        /// <param name="args">The args.</param>
        /// <returns>List{LocationAutoComplete}.</returns>
        public List<LocationAutoComplete> Execute(LocationAutoCompleteParameters args)
        {
            return _database
               .List<LocationAutoComplete, object>("Momento_GetLocationByFirstCharactersAndUsername", args)
               .ToList();
        }
    }

    public class LocationAutoCompleteParameters
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

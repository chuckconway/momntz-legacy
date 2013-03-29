using System.Collections.Generic;
using Momntz.Data.Projections;

namespace Momntz.UI.Areas.Users.Models
{
    public interface IGroupedView : ISignedUser
    {
        /// <summary>
        /// Gets or sets the path.
        /// </summary>
        /// <value>The path.</value>
        string Path { get; set; }

        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        /// <value>The items.</value>
        IList<IGroupItem> Items { get; set; }
    }
}
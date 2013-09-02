using Momntz.Data.Projections.Momentos;
using Momntz.UI.Areas.Users.Models;

namespace Momntz.UI.Models.Media
{
    public class SingleMediaView
    {
        /// <summary>
        /// Gets or sets the signed user.
        /// </summary>
        /// <value>The signed user.</value>
        public ISignedUser SignedUser { get; set; }

        /// <summary>
        /// Gets or sets the tile.
        /// </summary>
        /// <value>The tile.</value>
        public Tile Tile { get; set; }
    }
}
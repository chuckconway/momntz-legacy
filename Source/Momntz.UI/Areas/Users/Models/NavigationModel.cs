using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Momntz.UI.Areas.Users.Models
{
    public class NavigationModel
    {
        /// <summary>
        /// Gets or sets the signed user.
        /// </summary>
        /// <value>The signed user.</value>
        public ISignedUser SignedUser { get; set; }

        /// <summary>
        /// Gets or sets the visibility.
        /// </summary>
        /// <value>The visibility.</value>
        public NavigationVisiblity Visibility { get; set; }
    }

    public enum NavigationVisiblity
    {
        None,
        AddAlbum,
        AddImage
    }
}
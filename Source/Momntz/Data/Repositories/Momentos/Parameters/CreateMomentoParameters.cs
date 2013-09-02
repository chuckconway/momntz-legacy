using System.Collections.Generic;

namespace Momntz.Data.Repositories.Momentos.Parameters
{
    public class CreateMomentoParameters
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CreateMomentoParameters" /> class.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="media">The media.</param>
        public CreateMomentoParameters(string username, List<CreateMomentoMediaParameters> media)
        {
            Username = username;
            Media = media;
        }

        /// <summary>
        ///     Gets or sets the username.
        /// </summary>
        /// <value>The username.</value>
        public string Username { get; set; }

        public List<CreateMomentoMediaParameters> Media { get; set; }
    }
}
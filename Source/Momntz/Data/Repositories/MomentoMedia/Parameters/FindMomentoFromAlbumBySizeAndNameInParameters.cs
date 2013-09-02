namespace Momntz.Data.Repositories.MomentoMedia.Parameters
{
    public class FindMomentoFromAlbumBySizeAndNameInParameters
    {
        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        /// <value>The size.</value>
        public int Size { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Filename { get; set; }

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>The username.</value>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the album unique identifier.
        /// </summary>
        /// <value>The album unique identifier.</value>
        public int AlbumId { get; set; }
    }
}
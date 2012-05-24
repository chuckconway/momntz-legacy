namespace Momntz.Model
{
    public class MomentoMedia
    {
        /// <summary> Gets or sets the identifier. </summary>
        /// <value> The identifier. </value>
        public int Id { get; set; }

        /// <summary> Gets or sets the filename of the file. </summary>
        /// <value> The filename. </value>
        public string Filename { get; set; }

        /// <summary> Gets or sets the type of the file. </summary>
        /// <value> The type of the file. </value>
        public string FileType { get; set; }

        /// <summary> Gets or sets the bytes. </summary>
        /// <value> The bytes. </value>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        /// <value>
        /// The size.
        /// </value>
        public string Size { get; set; }

        /// <summary> Gets or sets the date of the upload. </summary>
        /// <value> The date of the upload. </value>
        public string CreateDate { get; set; }

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>
        /// The username.
        /// </value>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the type of the media.
        /// </summary>
        /// <value>
        /// The type of the media.
        /// </value>
        public string MediaType { get; set; }
    }
}

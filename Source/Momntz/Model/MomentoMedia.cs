namespace Momntz.Model
{
    public class MomentoMedia
    {
        /// <summary> Gets or sets the identifier. </summary>
        /// <value> The identifier. </value>
        public virtual int Id { get; set; }

        public virtual Momento Momento { get; set; }

        /// <summary> Gets or sets the filename of the file. </summary>
        /// <value> The filename. </value>
        public virtual string Filename { get; set; }

        /// <summary> Gets or sets the type of the file. </summary>
        /// <value> The type of the file. </value>
        public virtual string Extension { get; set; }

        /// <summary> Gets or sets the bytes. </summary>
        /// <value> The bytes. </value>
        public virtual string Url { get; set; }

        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        /// <value>
        /// The size.
        /// </value>
        public virtual string Size { get; set; }

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>
        /// The username.
        /// </value>
        public virtual string Username { get; set; }

        /// <summary>
        /// Gets or sets the type of the media.
        /// </summary>
        /// <value>
        /// The type of the media.
        /// </value>
        public virtual MediaType MediaType { get; set; }
    }

    public enum MediaType
    {
        WordDoc,
        PDF,
        Video,
        SmallImage,
        MediumImage,
        LargeImage,
        OriginalImage,
        Text
    }
}

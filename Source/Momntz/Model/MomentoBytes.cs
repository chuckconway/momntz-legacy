namespace Momntz.Model
{
    public class MomentoBytes
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
        public byte[] Bytes { get; set; }

        /// <summary> Gets or sets the date of the upload. </summary>
        /// <value> The date of the upload. </value>
        public string UploadDate { get; set; }
    }
}

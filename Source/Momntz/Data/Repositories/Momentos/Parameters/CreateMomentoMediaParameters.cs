using Momntz.Data.Schema;

namespace Momntz.Data.Repositories.Momentos.Parameters
{
    public class CreateMomentoMediaParameters
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CreateMomentoMediaParameters" /> class.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <param name="fileType">Type of the file.</param>
        /// <param name="url">The URL.</param>
        /// <param name="size">The size.</param>
        /// <param name="username">The username.</param>
        /// <param name="momentoMediaType">Type of the momento media.</param>
        public CreateMomentoMediaParameters(string filename, string fileType, string url, int size, string username,
            MomentoMediaType momentoMediaType)
        {
            Filename = filename;
            Extension = fileType;
            Url = url;
            Size = size;
            Username = username;
            MomentoMediaType = momentoMediaType;
        }

        public string Filename { get; set; }
        public string Extension { get; set; }
        public string Url { get; set; }
        public int Size { get; set; }
        public string Username { get; set; }
        public MomentoMediaType MomentoMediaType { get; set; }
        public int MomentoId { get; set; }
    }
}
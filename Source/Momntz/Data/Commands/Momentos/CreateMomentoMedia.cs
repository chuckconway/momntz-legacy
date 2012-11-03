using Momntz.Model;

namespace Momntz.Data.Commands.Momentos
{
    public class CreateMomentoMediaCommand
    {
        public string Filename { get; set; }
        public string Extension { get; set; }
        public string Url { get; set; }
        public int Size { get; set; }
        public string Username { get; set; }
        public MediaType MediaType { get; set; }
        public int MomentoId { get; set; }

        public CreateMomentoMediaCommand(string filename, string fileType, string url, int size, string username, MediaType mediaType )
        {
            Filename = filename;
            Extension = fileType;
            Url = url;
            Size = size;
            Username = username;
            MediaType = mediaType;
        }
    }
}

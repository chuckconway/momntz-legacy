using System;

namespace Momntz.Data.Commands.Tags
{
    public class CreateTagCommand
    {
        public string Name { get; set; }
        public int Left { get; set; }
        public int Top { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Username { get; set; }
        public int MomentoId { get; set; }
        public Guid InternalId { get; set; }

        public CreateTagCommand(string name, int left, int top, int width, int height, string username, int momentoId)
        {
            Name = name;
            Left = left;
            Top = top;
            Width = width;
            Height = height;
            Username = username;
            MomentoId = momentoId;
            InternalId = Guid.NewGuid();
        }
    }
}

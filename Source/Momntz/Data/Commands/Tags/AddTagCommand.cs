using System;

namespace Momntz.Data.Commands.Tags
{
    public class CreateTagCommand
    {
        public string Name { get; set; }
        public string Left { get; set; }
        public string Top { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }
        public string Username { get; set; }
        public Guid InternalId { get; set; }

        public CreateTagCommand(string name, string left, string top, string width, string height, string username, Guid internalId)
        {
            Name = name;
            Left = left;
            Top = top;
            Width = width;
            Height = height;
            Username = username;
            InternalId = internalId;
        }
    }
}

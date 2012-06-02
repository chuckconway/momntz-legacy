using System.Collections.Generic;
using Hypersonic.Attributes;

namespace Momntz.Data.Commands.Momentos
{
    public class CreateMomentoCommand
    {
        public string Username { get; set; }
        
        [Ignore]
        public List<CreateMomentoMediaCommand> Media { get; set; }

        public CreateMomentoCommand(string username, List<CreateMomentoMediaCommand> media)
        {
            Username = username;
            Media = media;
        }
    }
}

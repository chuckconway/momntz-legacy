using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Momntz.Data.Commands.Albums
{
    public class RemoveAlbumCommand: ICommand
    {
        public string Tag { get; set; }
        public string Username { get; set; }
        public int MomentoId { get; set; }

        public RemoveAlbumCommand(string tag, string username, int momentoId)
        {
            Tag = tag;
            Username = username;
            MomentoId = momentoId;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Momntz.Data.Projections
{
    public interface IGroupItem
    {
        string Username { get; set; }

        string Name { get; set; }

        string Url { get; set; }
    }
}

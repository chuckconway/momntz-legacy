using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Momntz.Data.Queries;

namespace Momntz.Data.Projections.Api
{
    public class AlbumNameResult : IQueryParameters
    {
        public string Name { get; set; }
    }
}

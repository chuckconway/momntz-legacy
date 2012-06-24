using System.Collections.Generic;
using Momntz.Model;

namespace Momntz.Data.Projections.Momentos
{
    public class MomentoWithMedia : IProjection
    {
        public Momento Momento { get; set; }

        public MomentoMedia Media { get; set; }

        public List<Tag> Tags { get; set; }
    }
}

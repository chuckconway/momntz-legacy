using Momntz.Model;

namespace Momntz.Data.Projections.Momentos
{
    public class HomepageMomento : IProjection
    {
        public Momento Momento { get; set; }

        public MomentoMedia Media { get; set; }
    }
}

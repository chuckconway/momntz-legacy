using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hypersonic;

namespace Momntz.Data
{
    public interface IDatabaseSession
    {
        ISession Session { get; }
    }
}

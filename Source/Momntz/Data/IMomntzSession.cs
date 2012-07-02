using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hypersonic;

namespace Momntz.Data
{
    public interface IMomntzSession : IDatabaseSession {}

    public class MomntzSession : IMomntzSession
    {
        public ISession Session { get; private set; }

        public MomntzSession(ISession session)
        {
            Session = session;
        }
    }
}

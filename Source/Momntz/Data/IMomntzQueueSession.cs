using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hypersonic;

namespace Momntz.Data
{
    public interface IMomntzQueueSession : IDatabaseSession
    {
        
    }

    public class MomntzQueueSession : IMomntzQueueSession
    {
        public ISession Session { get; private set; }

        public MomntzQueueSession(ISession session)
        {
            Session = session;
        }
    }
}

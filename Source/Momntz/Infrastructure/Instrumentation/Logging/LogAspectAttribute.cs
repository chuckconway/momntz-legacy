using System;
using PostSharp.Aspects;

namespace Momntz.Infrastructure.Instrumentation.Logging
{
    [Serializable]
    public abstract class LogAspectAttribute : OnMethodBoundaryAspect 
    {


        public abstract void Write(string log);

    }
}

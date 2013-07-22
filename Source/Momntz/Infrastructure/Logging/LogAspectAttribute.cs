using System;
using System.Globalization;
using Newtonsoft.Json;
using PostSharp.Aspects;

namespace Momntz.Infrastructure.Logging
{
    [Serializable]
    public abstract class LogAspectAttribute : OnMethodBoundaryAspect 
    {


        public abstract void Write(string log);

    }
}

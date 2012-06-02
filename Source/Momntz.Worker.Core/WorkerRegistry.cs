using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StructureMap.Configuration.DSL;

namespace Momntz.Worker.Core
{
    public class WorkerRegistry : Registry
    {
        public WorkerRegistry()
        {
            Scan(
                s =>
                {
                    s.TheCallingAssembly();
                    s.WithDefaultConventions();
                    //s.ConnectImplementationsToTypesClosing(typeof(ICommandHandler<>));
                    //s.ConnectImplementationsToTypesClosing(typeof(IProjectionHandler<,>));
                });
        }
    }
}

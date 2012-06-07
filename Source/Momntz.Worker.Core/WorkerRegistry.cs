using Chucksoft.Core.Services;
using Chucksoft.Storage;
using Hypersonic;
using Hypersonic.Session;
using StructureMap.Configuration.DSL;

namespace Momntz.Worker.Core
{
    public class WorkerRegistry : Registry
    {
        public WorkerRegistry()
        {
            For<ISession>().Use(SessionFactory.SqlServer());
            For<IStorage>().Use<AzureStorage>();
            For<IConfigurationService>().Use<ConfigurationService>();

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

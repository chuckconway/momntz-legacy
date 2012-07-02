using Hypersonic.Session;
using Momntz.Data;
using Momntz.Data.CommandHandlers;
using Momntz.Data.ProjectionHandlers;
using StructureMap.Configuration.DSL;

namespace Momntz
{
    public class MomntzRegistry : Registry 
    {
        public MomntzRegistry()
        {
            this.For<IMomntzSession>().Use(new MomntzSession(SessionFactory.SqlServer("sql")));
            this.For<IMomntzQueueSession>().Use(new MomntzQueueSession(SessionFactory.SqlServer("queue")));
            Scan(
                s =>
                    {
                        s.TheCallingAssembly();
                        s.WithDefaultConventions();
                        s.ConnectImplementationsToTypesClosing(typeof(ICommandHandler<>));
                        s.ConnectImplementationsToTypesClosing(typeof(IProjectionHandler<,>));
                    });
        }
    }
}

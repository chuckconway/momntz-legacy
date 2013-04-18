using Momntz.Data.CommandHandlers;
using Momntz.Data.ProjectionHandlers;
using Momntz.Infrastructure;
using Momntz.Model.Configuration;
using StructureMap.Configuration.DSL;

namespace Momntz
{
    public class MomntzRegistry : Registry 
    {
        public MomntzRegistry()
        {
            For<IMap>().Use<Mapper>();

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

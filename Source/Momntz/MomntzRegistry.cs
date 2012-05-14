using Momntz.Data.CommandHandlers;
using Momntz.Data.ProjectionHandlers;
using StructureMap.Configuration.DSL;

namespace Momntz
{
    public class MomntzRegistry : Registry 
    {
        public MomntzRegistry()
        {
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

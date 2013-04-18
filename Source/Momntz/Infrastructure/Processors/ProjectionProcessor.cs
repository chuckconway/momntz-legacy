using Momntz.Data.ProjectionHandlers;

namespace Momntz.Infrastructure.Processors
{
    public class ProjectionProcessor : IProjectionProcessor
    {
        private readonly IInjection _injection;

        /// <summary> Constructor. </summary>
        /// <param name="injection"> The injection. </param>
        public ProjectionProcessor(IInjection injection)
        {
            _injection = injection;
        }

        /// <summary> Process the given args. </summary>
        /// <typeparam name="TProjection"> Type of the arguments. </typeparam>
        /// <typeparam name="TReturn">     Type of the return. </typeparam>
        /// <param name="args"> The arguments. </param>
        /// <returns> . </returns>
        public TReturn Process<TProjection, TReturn>(TProjection args)
        {
            var commandHandler = _injection.Get<IProjectionHandler<TProjection, TReturn>>();
            return commandHandler.Execute(args);
        }
    }
}
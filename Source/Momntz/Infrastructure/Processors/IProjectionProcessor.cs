namespace Momntz.Infrastructure.Processors
{
    public interface IProjectionProcessor
    {
        /// <summary> Process the given args. </summary>
        /// <typeparam name="TProjection"> Type of the projection. </typeparam>
        /// <typeparam name="TReturn">     Type of the return. </typeparam>
        /// <param name="args"> The arguments. </param>
        /// <returns> . </returns>
        TReturn Process<TProjection, TReturn>(TProjection args);
    }
}

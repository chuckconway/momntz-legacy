namespace Momntz.Infrastructure
{
    public interface IMap
    {
        /// <summary>
        /// Maps the specified source.
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <typeparam name="D"></typeparam>
        /// <param name="source">The source.</param>
        /// <returns>``1.</returns>
        D Map<S, D>(S source);
    }
}

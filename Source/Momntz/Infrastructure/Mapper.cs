namespace Momntz.Infrastructure
{
    public class Mapper : IMap
    {
        /// <summary>
        /// Maps the specified source.
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <typeparam name="D"></typeparam>
        /// <param name="source">The source.</param>
        /// <returns>``1.</returns>
        public D Map<S, D>(S source)
        {
            return AutoMapper.Mapper.Map<S, D>(source);
        }
    }
}

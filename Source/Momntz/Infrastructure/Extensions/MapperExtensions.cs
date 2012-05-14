using AutoMapper;

namespace Momntz.Infrastructure.Extensions
{
    public static class MapperExtensions
    {
        /// <summary> An object extension method that toes. </summary>
        /// <typeparam name="T"> Generic type parameter. </typeparam>
        /// <param name="item"> The item to act on. </param>
        /// <returns> . </returns>
        public static T To<T>(this object item)
        {
           return Mapper.DynamicMap<T>(item);
        }
    }
}

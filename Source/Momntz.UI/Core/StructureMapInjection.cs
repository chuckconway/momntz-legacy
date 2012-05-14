using System.Web.Mvc;
using Momntz.Infrastructure;

namespace Momntz.UI.Core
{
    public class StructureMapInjection : IInjection
    {
        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T Get<T>()
        {
            return DependencyResolver.Current.GetService<T>();
        }
    }
}
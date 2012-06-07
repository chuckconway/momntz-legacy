using System;
using System.Collections;
using System.Collections.Generic;

namespace Momntz.Infrastructure
{
    public interface IInjection
    {
        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        T Get<T>();

        object Get(Type type);

        IList GetInstances(Type type);

        IList<T> GetInstances<T>();

        void AddManifest(object manifest);

    }
}
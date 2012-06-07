
using System;
using System.Collections;
using System.Collections.Generic;
using StructureMap;
using StructureMap.Configuration.DSL;

namespace Momntz.Infrastructure
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
            return ObjectFactory.GetInstance<T>();
        }
        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public object Get(Type type)
        {
            return ObjectFactory.GetInstance(type);
        }

        public IList<T> GetInstances<T>()
        {
            return ObjectFactory.GetAllInstances<T>();
        }

        public IList GetInstances(Type type)
        {
            return ObjectFactory.GetAllInstances(type);
        }

        public void AddManifest(object manifest)
        {
            ObjectFactory.Configure(c => c.AddRegistry((Registry)manifest));
        }
    }
}
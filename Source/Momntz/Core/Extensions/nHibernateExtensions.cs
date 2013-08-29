using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NHibernate;
using NHibernate.Transform;

namespace Momntz.Core.Extensions
{
    public static class NHibernateExtensions
    {
        /// <summary>
        /// Creates the command procedure.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="session">The session.</param>
        /// <param name="procedure">The procedure.</param>
        /// <param name="values">The values.</param>
        /// <returns>IQuery.</returns>
        public static IQuery CreateCommandProcedure<T>(this ISession session, string procedure, T values)
        {
            var properties = values.GetType().GetProperties();

            var query = string.Format(@"exec  {0} ", procedure);

            var names =(from p in properties
            select string.Format("@{0}=:{0}", p.Name)).ToArray();

            query += string.Join(", ", names);
            
            var q = session.CreateSQLQuery(query);

            foreach (var info in properties)
            {
                q.GetType().InvokeMember("SetParameter", BindingFlags.InvokeMethod, null, q, new[] { info.Name, info.GetValue(values) });
            }

            return q;
        }

        /// <summary>
        /// Creates the command procedure.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult">The type of the attribute result.</typeparam>
        /// <param name="session">The session.</param>
        /// <param name="procedure">The procedure.</param>
        /// <param name="values">The values.</param>
        /// <returns>IQuery.</returns>
        public static IQuery CreateQueryProcedure<TResult>(this ISession session, string procedure, object values) where TResult : class
        {
            Transform t = new Transform();

            return CreateCommandProcedure(session, procedure, values).SetResultTransformer(t);
        }
    }

    public class Transform : IResultTransformer
    {
        /// <summary>
        /// Transforms the tuple.
        /// </summary>
        /// <param name="tuple">The tuple.</param>
        /// <param name="aliases">The aliases.</param>
        /// <returns>System.Object.</returns>
        public object TransformTuple(object[] tuple, string[] aliases)
        {
            IDictionary<string,string> row = new Dictionary<string, string>();

            for (int index = 0; index < aliases.Length; index++)
            {
                row.Add(aliases[index], Convert.ToString(tuple[index]));
            }

            return row;
        }

        /// <summary>
        /// Transforms the list.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <returns>IList.</returns>
        public IList TransformList(IList collection)
        {
            return collection;
        }
    }
}

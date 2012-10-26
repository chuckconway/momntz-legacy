using System;
using System.Collections.Generic;
using System.Configuration;
using Chucksoft.Core.Services;
using System.Linq;
using Momntz.Model.Configuration;
using NHibernate;
using NHibernate.Criterion;

namespace Momntz.Infrastructure
{
    public class MomntzConfiguration : IConfigurationService
    {
        private readonly ISessionFactory _session;
        private static IList<Setting> _settings;

        /// <summary>
        /// Initializes a new instance of the <see cref="MomntzConfiguration" /> class.
        /// </summary>
        /// <param name="session">The session.</param>
        public MomntzConfiguration(ISessionFactory session)
        {
            _session = session;
        }

        /// <summary>
        /// Gets the value by key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>System.String.</returns>
        public string GetValueByKey(string key)
        {
            _settings = GetValues(); 
            var singleOrDefault = _settings.SingleOrDefault(s => string.Equals(s.Name, key, StringComparison.CurrentCultureIgnoreCase));

            string val = null;
            if (singleOrDefault != null)
            {
                val = singleOrDefault.Value;
            }

            return val;
        }

        /// <summary>
        /// Gets the values.
        /// </summary>
        /// <returns>IList{Setting}.</returns>
        private IList<Setting> GetValues()
        {
            string environment = ConfigurationManager.AppSettings["Environment"];

            using (var session =_session.OpenSession())
            {
             var list = session.QueryOver<Setting>()
                    .Where(Restrictions.Or(
                        Restrictions.Eq("Environment", null),
                        Restrictions.Eq("Environment", environment)))
                    .List();

             return list;
            }
            
        }
    }
}

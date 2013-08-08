using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using NHibernate;
using NHibernate.Criterion;

namespace Momntz.Infrastructure.Configuration
{
    public class MomntzConfiguration : IConfigurationService
    {
        private readonly ISession _session;

        private static IList<Setting> _settings;
        private static readonly object _lock = new object();

        /// <summary>
        /// Gets the storage settings.
        /// </summary>
        /// <returns>ApplicationSettings.</returns>
        public static ApplicationSettings GetSettings()
        {
            var settings = new ApplicationSettings();

            using (var session = new Database().CreateSessionFactory().OpenSession())
            {
                IConfigurationService configuration = new MomntzConfiguration(session);
                settings.CloudUrl = configuration.GetValueByKey("cloudurl");
                settings.CloudAccount = configuration.GetValueByKey("cloudaccount");
                settings.CloudKey = configuration.GetValueByKey("cloudkey");
                settings.ServiceBusEndpoint = configuration.GetValueByKey("ServiceBus.Queue");
                settings.LoggingFilePath = configuration.GetValueByKey("LogToFile");
                settings.UILoggingEndpoint = configuration.GetValueByKey("UILogging.Endpoint");
                settings.ServiceLoggingEndpoint = configuration.GetValueByKey("ServiceLogging.Endpoint");
            }

            return settings;
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="MomntzConfiguration" /> class.
        /// </summary>
        /// <param name="session">The session.</param>
        public MomntzConfiguration(ISession session)
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
            IList<Setting> items = _settings;

            if (_settings == null)
            {
                lock (_lock)
                {
                    string environment = ConfigurationManager.AppSettings["Environment"];

                    using (var trans = _session.BeginTransaction())
                    {
                        _settings = _session.QueryOver<Setting>()
                                           .Where(Restrictions.Or(Restrictions.IsNull("Environment"),
                                                                  Restrictions.Eq("Environment", environment)))
                                           .List();

                        trans.Commit();
                        items = _settings;
                    }
                }

            }

            return items;
        }
    }

    public class ApplicationSettings
    {
        /// <summary>
        /// Gets or sets the cloud URL.
        /// </summary>
        /// <value>The cloud URL.</value>
        public string CloudUrl { get; set; }

        /// <summary>
        /// Gets or sets the cloud account.
        /// </summary>
        /// <value>The cloud account.</value>
        public string CloudAccount { get; set; }

        /// <summary>
        /// Gets or sets the cloud key.
        /// </summary>
        /// <value>The cloud key.</value>
        public string CloudKey { get; set; }

        /// <summary>
        /// Gets or sets the service bus endpoint.
        /// </summary>
        /// <value>The service bus endpoint.</value>
        public string ServiceBusEndpoint { get; set; }

        /// <summary>
        /// Gets or sets the log to file path.
        /// </summary>
        /// <value>The log to file path.</value>
        public string LoggingFilePath { get; set; }

        /// <summary>
        /// Gets or sets the type of the logger.
        /// </summary>
        /// <value>The type of the logger.</value>
        public string LoggerType { get; set; }

        /// <summary>
        /// Gets or sets the UI logging endpoint.
        /// </summary>
        /// <value>The UI logging endpoint.</value>
        public string UILoggingEndpoint { get; set; }

        /// <summary>
        /// Gets or sets the service logging endpoint.
        /// </summary>
        /// <value>The service logging endpoint.</value>
        public string ServiceLoggingEndpoint { get; set; }

    }
}

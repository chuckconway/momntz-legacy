using System;
using System.Collections.Generic;
using System.Configuration;
using Chucksoft.Core.Services;
using Hypersonic;
using Momntz.Model;
using System.Linq;

namespace Momntz.Infrastructure
{
    public class MomntzConfiguration : IConfigurationService
    {
        private readonly ISession _session;
        private static IList<Setting> _settings;

        public MomntzConfiguration(ISession session)
        {
            _session = session;
        }

        public string GetValueByKey(string key)
        {
            _settings = _settings ?? GetValues(); 
            var singleOrDefault = _settings.SingleOrDefault(s => string.Equals(s.Key, key, StringComparison.CurrentCultureIgnoreCase));

            string val = null;
            if (singleOrDefault != null)
            {
                val = singleOrDefault.Value;
            }

            return val;
        }

        private IList<Setting> GetValues()
        {
            string environment = ConfigurationManager.AppSettings["Environment"];
            var settings = _session.Query<Setting>("Configuration").Where(s => s.Environment == null || s.Environment == environment).List();

            return settings;
        }
    }
}

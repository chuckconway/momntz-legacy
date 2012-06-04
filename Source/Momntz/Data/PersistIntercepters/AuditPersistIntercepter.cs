using System;
using System.Web.Script.Serialization;
using Hypersonic;
using Hypersonic.Session.Persistance;

namespace Momntz.Data.PersistIntercepters
{
    public class AuditPersistIntercepter: IPersistIntercepter
    {
        private const string _audit = "Audit";

        public Persist Intercept(Persist persist, ISession session)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string s = serializer.Serialize(persist.Instance);

            var audit = new { Item = s, ItemType = persist.TableName };
            session.Save(audit, _audit);

            return persist;
        }

        public Func<string, bool> Condition
        {
            get { return s => !string.Equals(s, _audit, StringComparison.InvariantCulture) &&
                              !string.Equals(s, "Media", StringComparison.InvariantCulture) &&
                              !string.Equals(s, "Queue", StringComparison.InvariantCulture);
            }
        }
    }
}

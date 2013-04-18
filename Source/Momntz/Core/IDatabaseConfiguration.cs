using NHibernate;

namespace Momntz.Core
{
    public interface IDatabaseConfiguration
    {
        /// <summary>
        /// Creates the session factory.
        /// </summary>
        /// <returns>ISessionFactory.</returns>
        ISessionFactory CreateSessionFactory();

        /// <summary>
        /// Creates the session factory.
        /// </summary>
        /// <returns>ISessionFactory.</returns>
        ISessionFactory CreateSessionFactory(string connectionString);
    }
}
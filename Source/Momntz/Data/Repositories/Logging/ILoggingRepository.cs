using Momntz.Data.Repositories.Logging.Parameters;

namespace Momntz.Data.Repositories.Logging
{
    public interface ILoggingRepository
    {
        /// <summary>
        ///     Executes the specified parameters.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        void Log(SaveLoggingParameters parameters);
    }
}
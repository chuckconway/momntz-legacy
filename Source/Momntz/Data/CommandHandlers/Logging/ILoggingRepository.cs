using Momntz.Data.CommandHandlers.Logging.Parameters;

namespace Momntz.Data.CommandHandlers.Logging
{
    public interface ILoggingRepository
    {
        /// <summary>
        /// Executes the specified parameters.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        void Log(SaveLoggingParameters parameters);
    }
}

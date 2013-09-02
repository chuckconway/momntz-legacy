using Momntz.Data.Repositories.Logging;
using Momntz.Data.Repositories.Logging.Parameters;

namespace Momntz.Infrastructure.Instrumentation.Logging
{
    public class LogToCloud : LogBase
    {
        private readonly ILoggingRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="LogToCloud" /> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public LogToCloud(ILoggingRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Persists the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        protected override void Persist(string message)
        {
            _repository.Log(new SaveLoggingParameters(){Message = message});
        }
    }
}

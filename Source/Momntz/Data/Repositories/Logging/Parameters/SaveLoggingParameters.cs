namespace Momntz.Data.Repositories.Logging.Parameters
{
    public class SaveLoggingParameters
    {
        /// <summary>
        ///     Gets or sets the message.
        /// </summary>
        /// <value>The message.</value>
        public string Message { get; set; }

        /// <summary>
        ///     Gets or sets the rest logging endpoint.
        /// </summary>
        /// <value>The rest logging endpoint.</value>
        public string RestLoggingEndpoint { get; set; }
    }
}
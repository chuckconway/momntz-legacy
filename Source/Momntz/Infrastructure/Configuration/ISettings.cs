namespace Momntz.Infrastructure.Configuration
{
    public interface ISettings
    {
        /// <summary>
        /// Gets the cloud URL.
        /// </summary>
        /// <value>The cloud URL.</value>
        string CloudUrl { get; }

        /// <summary>
        /// Gets the cloud account.
        /// </summary>
        /// <value>The cloud account.</value>
        string CloudAccount { get; }

        /// <summary>
        /// Gets the cloud key.
        /// </summary>
        /// <value>The cloud key.</value>
        string CloudKey { get; }

        /// <summary>
        /// Gets the queue database.
        /// </summary>
        /// <value>The queue database.</value>
        string QueueDatabase { get; }

        int ImageSmallWidth { get; }

        int ImageSmallHeight { get; }

        int ImageMediumWidth { get; }

        int ImageMediumHeight { get; }

        int ImageLargeWidth { get; }

        int ImageLargeHeight { get; }
    }
}

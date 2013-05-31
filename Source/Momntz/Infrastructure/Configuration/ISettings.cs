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
        /// Gets the width of the image small.
        /// </summary>
        /// <value>The width of the image small.</value>
        int ImageSmallWidth { get; }

        /// <summary>
        /// Gets the height of the image small.
        /// </summary>
        /// <value>The height of the image small.</value>
        int ImageSmallHeight { get; }

        /// <summary>
        /// Gets the width of the image medium.
        /// </summary>
        /// <value>The width of the image medium.</value>
        int ImageMediumWidth { get; }

        /// <summary>
        /// Gets the height of the image medium.
        /// </summary>
        /// <value>The height of the image medium.</value>
        int ImageMediumHeight { get; }

        /// <summary>
        /// Gets the width of the image large.
        /// </summary>
        /// <value>The width of the image large.</value>
        int ImageLargeWidth { get; }

        /// <summary>
        /// Gets the height of the image large.
        /// </summary>
        /// <value>The height of the image large.</value>
        int ImageLargeHeight { get; }
    }
}

using System;

namespace Momntz.Infrastructure.Configuration
{
    public class Settings : ISettings
    {
        private readonly IConfigurationService _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="Settings"/> class.
        /// </summary>
        /// <param name="service">The service.</param>
        public Settings(IConfigurationService service)
        {
            _service = service;
        }

        /// <summary>
        /// Gets the cloud URL.
        /// </summary>
        /// <value>The cloud URL.</value>
        public string CloudUrl
        {
            get { return _service.GetValueByKey("cloudurl"); }
        }

        /// <summary>
        /// Gets the cloud URL.
        /// </summary>
        /// <value>The cloud URL.</value>
        public string CloudAccount
        {
            get { return _service.GetValueByKey("cloudaccount"); }
        }

        /// <summary>
        /// Gets the cloud URL.
        /// </summary>
        /// <value>The cloud URL.</value>
        public string CloudKey
        {
            get { return _service.GetValueByKey("cloudkey"); }
        }

        /// <summary>
        /// Gets the width of the image small.
        /// </summary>
        /// <value>The width of the image small.</value>
        public int ImageSmallWidth { get { return Convert.ToInt32(_service.GetValueByKey("Image.Small.Width")); } }

        /// <summary>
        /// Gets the height of the image small.
        /// </summary>
        /// <value>The height of the image small.</value>
        public int ImageSmallHeight { get { return Convert.ToInt32(_service.GetValueByKey("Image.Small.Height")); } }

        /// <summary>
        /// Gets the width of the image medium.
        /// </summary>
        /// <value>The width of the image medium.</value>
        public int ImageMediumWidth { get { return Convert.ToInt32(_service.GetValueByKey("Image.Medium.Width")); } }

        /// <summary>
        /// Gets the height of the image medium.
        /// </summary>
        /// <value>The height of the image medium.</value>
        public int ImageMediumHeight { get { return Convert.ToInt32(_service.GetValueByKey("Image.Medium.Height")); } }

        /// <summary>
        /// Gets the width of the image large.
        /// </summary>
        /// <value>The width of the image large.</value>
        public int ImageLargeWidth { get { return Convert.ToInt32(_service.GetValueByKey("Image.Large.Width")); } }

        /// <summary>
        /// Gets the height of the image large.
        /// </summary>
        /// <value>The height of the image large.</value>
        public int ImageLargeHeight { get { return Convert.ToInt32(_service.GetValueByKey("Image.Large.Height")); } }
    }
}

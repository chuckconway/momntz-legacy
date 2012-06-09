using System;
using Chucksoft.Core.Services;

namespace Momntz.Model.Configuration
{
    public class Settings : ISettings
    {
        private readonly IConfigurationService _service;

        public Settings(IConfigurationService service)
        {
            _service = service;
        }

        public string CloudUrl
        {
            get { return _service.GetValueByKey("cloudurl"); }
        }

        public string QueueDatabase
        {
            get { return _service.GetValueByKey("Database.Queue"); }
        }

        public int ImageSmallWidth { get { return Convert.ToInt32(_service.GetValueByKey("Image.Small.Width")); } }

        public int ImageSmallHeight { get { return Convert.ToInt32(_service.GetValueByKey("Image.Small.Height")); } }

        public int ImageMediumWidth { get { return Convert.ToInt32(_service.GetValueByKey("Image.Medium.Width")); } }

        public int ImageMediumHeight { get { return Convert.ToInt32(_service.GetValueByKey("Image.Medium.Height")); } }

        public int ImageLargeWidth { get { return Convert.ToInt32(_service.GetValueByKey("Image.Large.Width")); } }

        public int ImageLargeHeight { get { return Convert.ToInt32(_service.GetValueByKey("Image.Large.Height")); } }
    }
}

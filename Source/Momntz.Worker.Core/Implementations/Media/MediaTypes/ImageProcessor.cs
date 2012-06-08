using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using Chucksoft.Core.Drawing;
using Chucksoft.Storage;
using System.Linq;
using Hypersonic;
using Momntz.Model;
using Momntz.Model.Configuration;

namespace Momntz.Worker.Core.Implementations.Media.MediaTypes
{
    public class ImageProcessor : MediaBase, IMedia
    {
        private readonly ISettings _settings;
        private readonly ISession _session;

        static readonly List<Format> _formats =  new List<Format>
                {
                    new Format {ImageFormat = ImageFormat.Bmp, Extensions=new[]{"bmp"}},
                    new Format {ImageFormat = ImageFormat.Gif, Extensions=new[]{"gif"}},
                    new Format {ImageFormat = ImageFormat.Jpeg, Extensions=new[]{"jpg", "jpeg"}},
                    new Format {ImageFormat = ImageFormat.Png, Extensions=new[]{"png"}},
                    new Format {ImageFormat = ImageFormat.Tiff, Extensions=new[]{"tiff"}},
                };

        public ImageProcessor(IStorage storage, ISettings settings, ISession session) :base(storage)
        {
            _settings = settings;
            _session = session;
        }

        public string Media
        {
            get { return "Image"; }
        }

        private ImageFormat GetFormat(string imageFormat)
        {
            var item = _formats.SingleOrDefault(f => f.Extensions.Any(s => string.Equals(s, imageFormat.Trim('.'), StringComparison.InvariantCulture)));

            if(item != null)
            {
                return item.ImageFormat;
            }

            return null;
        }

        private void Save(string name, MediaType mediaType, MediaItem image)
        {
            _session.Save(new {InternalId = image.Id, image.Username, UploadedBy = image.Username},"Momento");
            var single = _session.Query<Momento>().Where(m => m.InternalId == image.Id).Single();

            _session.Save(
                new
                    {
                        image.Filename,
                        image.Size,
                        MomentoId = single.Id,
                        image.Extension,
                        Url = "img/" + name,
                        image.Username,
                        MediaType = mediaType
                    }, "MomentoMedia");
        }


        public void Process(MediaItem message)
        {
            ImageFormat format = GetFormat(message.Extension);
            
            SaveImage(MediaType.SmallImage, _settings.ImageSmallWidth, _settings.ImageSmallHeight, format, message);
            SaveImage(MediaType.MediumImage, _settings.ImageMediumWidth, _settings.ImageMediumHeight, format, message);
            SaveImage(MediaType.LargeImage, _settings.ImageLargeWidth, _settings.ImageLargeHeight, format, message);
            SaveImage(MediaType.OriginalImage, int.MaxValue, int.MaxValue, format, message);

            _session.Database.ConnectionString = _settings.QueueDatabase;
            _session.Database.CommandType = CommandType.Text;
            
            _session.Database.NonQuery(string.Format("Delete From Media Where Id = '{0}'", message.Id));

            //Reset to momntz database
            _session.Database.ConnectionString = null;
        }

        private void SaveImage(MediaType mediaType, int maxWidth, int maxHeight, ImageFormat format, MediaItem message)
        {
            byte[] bytes = null;

            if (maxWidth < int.MaxValue && maxHeight < int.MaxValue)
            {
                bytes = message.Bytes.ResizeToMax(new Size(maxWidth, maxHeight), format);
            }

            string type = message.Extension.TrimStart('.');
            string name = string.Format("{0}_{1}{2}", Path.GetFileNameWithoutExtension(message.Filename), DateTime.Now.Ticks, message.Extension);

            AddToStorage("img", "image", name, type, bytes ?? message.Bytes);
            Save(name, mediaType, message);
        }

        private class Format
        {
            public ImageFormat ImageFormat { get; set; }

            public string[] Extensions { get; set; }
        }
    }
}
